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
    }

    async UniTaskVoid UseSkill()
    {
        await UniTask.WaitUntil(() => GetCanUseSkill);
        while (true)
        {
            if(GameStateManager.Instance.GetIsGamePaused) return;
            await UniTask.Delay(TimeSpan.FromSeconds(GetSkillCoolDown()));

            Skill().Forget();
        }
    }

    async UniTaskVoid Skill()
    {
        CancellationTokenSource cts = new();

        for (int i = 0; i < InventorySystem.Instance.GetSkillSO(11).ProjectileCount; i++)
        {
            // bulunduğu yere spawnla
            await UniTask.Delay(TimeSpan.FromSeconds(.1f), cancellationToken: cts.Token);
        }

        cts.Cancel();
    }

    void OnDestroy() 
    {
        InventorySystem.Instance.OnNewSkillGain -= InventorySystem_OnNewSkillGain;
    }
    
}
