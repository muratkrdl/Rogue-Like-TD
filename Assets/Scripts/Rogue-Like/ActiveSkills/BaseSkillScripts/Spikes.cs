using System;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class Spikes : ActiveSkillBaseClass
{
    [SerializeField] PlayerEnemyKeeper playerEnemyKeeper;

    string animName = ConstStrings.ANIM;

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
            await UniTask.WaitUntil(() => playerEnemyKeeper.EnemiesInRange());
            
            Skill();
        }
    }

    void Skill()
    {
        if(!GlobalUnitTargets.Instance.CanPlayerUseSkill()) return;

        StopAllCoroutines();
        StartCoroutine(nameof(SkillCDSlider));

        var projectile = ActiveSkillProjectileObjectPool.Instance.GetProjectile(4);

        SoundManager.Instance.PlaySound2D(ConstStrings.SPIKE);

        projectile.GetComponent<Animator>().SetTrigger(animName);
        projectile.GetComponent<SpikeDamager>().SetDamageOnSpawn();
        projectile.transform.position = playerEnemyKeeper.GetClosestEnemy().position;
        projectile.transform.localScale = GetCurrentScale;
    }

    protected override void EvolveSkill()
    {
        animName = ConstStrings.ANIM1;
    }

    void OnDestroy() 
    {
        InventorySystem.Instance.OnNewSkillGain += InventorySystem_OnNewSkillGain;
        InventorySystem.Instance.OnSkillUpdate += InventorySystem_OnSkillUpdate;
        InventorySystem.Instance.OnSkillEvolved -= InventorySystem_OnSkillEvolved;
        UnSubInventoryCDEvent();
        OnDestroy_CancelCTS();
    }
    
}
