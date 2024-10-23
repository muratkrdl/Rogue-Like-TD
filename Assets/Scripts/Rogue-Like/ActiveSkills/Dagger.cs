using System;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class Dagger : ActiveSkillBaseClass
{
    [SerializeField] GameObject projectilePrefab;

    void Start() 
    {
        UseSkill().Forget();
        InventorySystem.Instance.OnNewSkillGain += InventorySystem_OnNewSkillGain;
    }

    async UniTaskVoid UseSkill()
    {
        await UniTask.WaitUntil(() => GetCanUseSkill);
        while (true)
        {
            await UniTask.WaitUntil(() => !GameStateManager.Instance.GetIsGamePaused);
            await UniTask.Delay(TimeSpan.FromSeconds(GetSkillCoolDown()));
            await UniTask.WaitUntil(() => !GameStateManager.Instance.GetIsGamePaused);

            Skill().Forget();
        }
    }

    async UniTaskVoid Skill()
    {
        for (int i = 0; i < InventorySystem.Instance.GetSkillSO(13).ProjectileCount; i++)
        {
            await UniTask.Delay(TimeSpan.FromSeconds(.1f));

            var projectile = ActiveSkillProjectileObjectPool.Instance.GetProjectile(1);
            if(GetComponentInParent<GetInputs>().GetMoveInput == Vector2.zero)
            {
                projectile.SetLookPos(GetComponentInParent<GetInputs>().GetLastMoveDir, transform.position);
            }
            else
            {
                projectile.SetLookPos(GetComponentInParent<GetInputs>().GetMoveInput, transform.position);
            }
            projectile.SetBaseClassValues(InventorySystem.Instance.GetSkillSO(10).Value);
        }
    }

    void OnDestroy() 
    {
        InventorySystem.Instance.OnNewSkillGain -= InventorySystem_OnNewSkillGain;
    }

}
