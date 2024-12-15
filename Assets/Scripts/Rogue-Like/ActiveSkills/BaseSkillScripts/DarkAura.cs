using System;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class DarkAura : ActiveSkillBaseClass
{
    [SerializeField] DarkAuraDamager darkAuraDamager;

    [SerializeField] Animator myAnimator;

    void Start() 
    {
        UseSkill().Forget();
        InventorySystem.Instance.OnNewSkillGain += InventorySystem_OnNewSkillGain;
        InventorySystem.Instance.OnSkillUpdate += InventorySystem_OnSkillUpdate;
        InventorySystem.Instance.OnSkillEvolved += InventorySystem_OnSkillEvolved;
        SubInventoryCDEvent();
    }

    async UniTaskVoid UseSkill()
    {
        await UniTask.WaitUntil(() => GetCanUseSkill);
        while (true)
        {
            await UniTask.WaitUntil(() => GlobalUnitTargets.Instance.CanPlayerUseSkill(), cancellationToken: GetCTS.Token);
            await UniTask.Delay(TimeSpan.FromSeconds(GetSkillCoolDown()));

            Skill();
        }
    }

    void Skill()
    {
        if(!GlobalUnitTargets.Instance.CanPlayerUseSkill()) return;
        
        StopAllCoroutines();
        StartCoroutine(nameof(SkillCDSlider));

        myAnimator.transform.localScale = GetCurrentScale;
        myAnimator.SetTrigger(ConstStrings.ANIM);
    }

    protected override void OnSkillGainedFunc()
    {
        darkAuraDamager.SetDamageOnSpawn();
    }

    protected override void OnSkillUpdateFunc()
    {
        darkAuraDamager.SetDamageOnSpawn();
    }

    protected override void EvolveSkill()
    {
        myAnimator.GetComponent<SpriteRenderer>().color = new(0, 1, 1, 0.6F);
    }

    void OnDestroy() 
    {
        InventorySystem.Instance.OnNewSkillGain -= InventorySystem_OnNewSkillGain;
        InventorySystem.Instance.OnSkillUpdate -= InventorySystem_OnSkillUpdate;
        InventorySystem.Instance.OnSkillEvolved -= InventorySystem_OnSkillEvolved;
        UnSubInventoryCDEvent();
        OnDestroy_CancelCTS();
    }
}
