using System;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class Tornado : ActiveSkillBaseClass
{
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
            await UniTask.WaitUntil(() => GlobalUnitTargets.Instance.CanPlayerUseSkill());
            await UniTask.Delay(TimeSpan.FromSeconds(GetSkillCoolDown()));

            Skill().Forget();
        }
    }

    async UniTaskVoid Skill()
    {
        if(!GlobalUnitTargets.Instance.CanPlayerUseSkill()) return;

        for(int i = 0; i < InventorySystem.Instance.GetSkillSO(GetSkillCode).ProjectileCount; i++)
        {
            await UniTask.WaitUntil(() => GlobalUnitTargets.Instance.CanPlayerUseSkill());
            await UniTask.Delay(TimeSpan.FromSeconds(.17f));
            await UniTask.WaitUntil(() => GlobalUnitTargets.Instance.CanPlayerUseSkill());

            var projectile = ActiveSkillProjectileObjectPool.Instance.GetProjectile(5);
            projectile.GetComponent<TornadoDamager>().ClearList();
            projectile.GetComponent<Animator>().SetTrigger(ConstStrings.ANIM);
            
            Vector2 newDirection = new(UnityEngine.Random.Range(UnityEngine.Random.Range(-1, -.1f), UnityEngine.Random.Range(.1f, 1)), UnityEngine.Random.Range(UnityEngine.Random.Range(-1, -.1f), UnityEngine.Random.Range(.1f, 1)));

            if(newDirection.x > 0)
                projectile.GetComponent<SpriteRenderer>().flipX = false;
            else
                projectile.GetComponent<SpriteRenderer>().flipX = true;

            projectile.SetMoveableProjectile(newDirection, transform.position, false);
            projectile.SetBaseClassValues(InventorySystem.Instance.GetSkillSO(GetSkillCode).Value, GetIsEvolved);
        }
    }

    void OnDestroy() 
    {
        InventorySystem.Instance.OnNewSkillGain -= InventorySystem_OnNewSkillGain;
    }
    
}
