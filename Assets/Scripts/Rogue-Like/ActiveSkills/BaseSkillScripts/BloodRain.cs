using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class BloodRain : ActiveSkillBaseClass
{

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

        var projectile = ActiveSkillProjectileObjectPool.Instance.GetProjectile(1);
        projectile.GetComponent<Animator>().SetTrigger(ConstStrings.RESET);
        projectile.SetBaseClassValues(InventorySystem.Instance.GetSkillSO(GetSkillCode).Value, GetIsEvolved);
        projectile.transform.position = transform.position;
        projectile.transform.localScale = GetCurrentScale;
    }

    void OnDestroy() 
    {
        InventorySystem.Instance.OnNewSkillGain -= InventorySystem_OnNewSkillGain;
        InventorySystem.Instance.OnSkillUpdate -= InventorySystem_OnSkillUpdate;
    }
    
}
