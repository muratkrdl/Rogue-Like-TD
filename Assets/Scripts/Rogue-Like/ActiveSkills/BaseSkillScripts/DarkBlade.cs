using System;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class DarkBlade : ActiveSkillBaseClass
{
    [SerializeField] Animator darkBladeAnimator;

    [SerializeField] SpriteRenderer darkBladeSpriteRenderer;

    [SerializeField] Sprite evolvedSprite;

    void Start() 
    {
        UseSkill().Forget();
        InventorySystem.Instance.OnNewSkillGain += InventorySystem_OnNewSkillGain;
        InventorySystem.Instance.OnSkillUpdate += InventorySystem_OnSkillUpdate;
        InventorySystem.Instance.OnSkillEvolved += InventorySystem_OnSkillEvolved;
    }

    async UniTaskVoid UseSkill()
    {
        await UniTask.WaitUntil(() => GetCanUseSkill);
        while (true)
        {
            await UniTask.WaitUntil(() => GlobalUnitTargets.Instance.CanPlayerUseSkill());
            await UniTask.Delay(TimeSpan.FromSeconds(GetSkillCoolDown()));

            Skill();
        }
    }

    void Skill()
    {
        if(!GlobalUnitTargets.Instance.CanPlayerUseSkill()) return;

        darkBladeAnimator.transform.localScale = GetCurrentScale;
        darkBladeAnimator.SetTrigger(ConstStrings.ANIM);
    }

    protected override void EvolveSkill()
    {
        darkBladeSpriteRenderer.sprite = evolvedSprite;
    }

    void OnDestroy() 
    {
        InventorySystem.Instance.OnNewSkillGain -= InventorySystem_OnNewSkillGain;
        InventorySystem.Instance.OnSkillUpdate -= InventorySystem_OnSkillUpdate;
        InventorySystem.Instance.OnSkillEvolved -= InventorySystem_OnSkillEvolved;
    }

}
