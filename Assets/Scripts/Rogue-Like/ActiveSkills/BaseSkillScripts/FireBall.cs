using System;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FireBall : ActiveSkillBaseClass
{
    int projectileCode = 3;

    Vector2 randomRangeRange = new(-.15f, .15f);

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
            await UniTask.WaitUntil(() => GlobalUnitTargets.Instance.CanPlayerUseSkill(), cancellationToken: GetCTS.Token);
            
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
            await UniTask.WaitUntil(() => GlobalUnitTargets.Instance.CanPlayerUseSkill(), cancellationToken: GetCTS.Token);
            await UniTask.Delay(TimeSpan.FromSeconds(.2f));
            await UniTask.WaitUntil(() => GlobalUnitTargets.Instance.CanPlayerUseSkill(), cancellationToken: GetCTS.Token);

            var projectile = ActiveSkillProjectileObjectPool.Instance.GetProjectile(projectileCode);
            
            Vector2 extraForce = Vector2.zero;
            Vector2 newLookPos;
            
            if(GetComponentInParent<GetInputs>().GetMoveInput == Vector2.zero)
                newLookPos = GetComponentInParent<GetInputs>().GetLastMoveDir;
            else
                newLookPos = GetComponentInParent<GetInputs>().GetMoveInput;

            if(Mathf.Abs(newLookPos.x) > Mathf.Abs(newLookPos.y))
                extraForce.y = UnityEngine.Random.Range(randomRangeRange.x, randomRangeRange.y);
            else
                extraForce.x = UnityEngine.Random.Range(randomRangeRange.x, randomRangeRange.y);

            projectile.GetComponent<FireballDamager>().ClearList();
            projectile.GetComponent<FireballDamager>().SetDamageOnSpawn();
            projectile.SetMoveableProjectile(newLookPos + extraForce, transform.position, true);
        }
    }

    protected override void EvolveSkill()
    {
        randomRangeRange = new(-.75f, .75f);
        projectileCode = 7;
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
