using System;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class Spikes : ActiveSkillBaseClass
{
    [SerializeField] PlayerEnemyKeeper playerEnemyKeeper;

    Vector2 currentScale = Vector2.one;

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
            await UniTask.WaitUntil(() => playerEnemyKeeper.EnemiesInRange());
            
            Debug.Log(playerEnemyKeeper.EnemiesInRange());

            Skill();
        }
    }

    void Skill()
    {
        if(!GlobalUnitTargets.Instance.CanPlayerUseSkill()) return;

        var projectile = ActiveSkillProjectileObjectPool.Instance.GetProjectile(4);
        projectile.GetComponent<Animator>().SetTrigger(ConstStrings.ANIM);
        projectile.SetBaseClassValues(InventorySystem.Instance.GetSkillSO(GetSkillCode).Value, GetIsEvolved);
        projectile.transform.position = playerEnemyKeeper.GetClosestEnemy().position;
        projectile.transform.localScale = GetCurrentScale;
    }

    void OnDestroy() 
    {
        InventorySystem.Instance.OnNewSkillGain += InventorySystem_OnNewSkillGain;
        InventorySystem.Instance.OnSkillUpdate += InventorySystem_OnSkillUpdate;
    }
    
}
