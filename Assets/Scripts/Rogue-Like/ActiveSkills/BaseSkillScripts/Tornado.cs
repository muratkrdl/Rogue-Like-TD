using System;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class Tornado : ActiveSkillBaseClass
{
    int projectileCode = 5;

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
            
            Skill().Forget();
        }
    }

    async UniTaskVoid Skill()
    {
        if(!GlobalUnitTargets.Instance.CanPlayerUseSkill()) return;

        StopAllCoroutines();
        StartCoroutine(nameof(SkillCDSlider));

        for(int i = 0; i < GetCurrentProjectileAmount; i++)
        {
            await UniTask.WaitUntil(() => GlobalUnitTargets.Instance.CanPlayerUseSkill());
            await UniTask.Delay(TimeSpan.FromSeconds(.17f));
            await UniTask.WaitUntil(() => GlobalUnitTargets.Instance.CanPlayerUseSkill());

            var projectile = ActiveSkillProjectileObjectPool.Instance.GetProjectile(projectileCode);
            projectile.GetComponent<TornadoDamager>().SetDamageOnSpawn();
            projectile.GetComponent<TornadoDamager>().ClearList();
            projectile.GetComponent<Animator>().SetTrigger(ConstStrings.ANIM);
            
            Vector2 newDirection = new(UnityEngine.Random.Range(UnityEngine.Random.Range(-1, -.1f), UnityEngine.Random.Range(.1f, 1)), UnityEngine.Random.Range(UnityEngine.Random.Range(-1, -.1f), UnityEngine.Random.Range(.1f, 1)));

            if(newDirection.x > 0)
                projectile.transform.localScale = Vector2.one;
            else
                projectile.transform.localScale = new(-1,1);

            projectile.SetMoveableProjectile(newDirection, transform.position, false);
        }
    }

    protected override void EvolveSkill()
    {
        projectileCode = 9;
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
