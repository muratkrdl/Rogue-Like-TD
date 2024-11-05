using System;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class DarkBlade : ActiveSkillBaseClass
{
    [SerializeField] Animator darkBladeAnimator;

    void Start() 
    {
        UseSkill().Forget();
        InventorySystem.Instance.OnNewSkillGain += InventorySystem_OnNewSkillGain;
        InventorySystem.Instance.OnSkillUpdate += InventorySystem_OnSkillUpdate;
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

        darkBladeAnimator.SetTrigger(ConstStrings.ANIM);
    }

    void OnDestroy() 
    {
        InventorySystem.Instance.OnNewSkillGain -= InventorySystem_OnNewSkillGain;
        InventorySystem.Instance.OnSkillUpdate -= InventorySystem_OnSkillUpdate;
    }

}
