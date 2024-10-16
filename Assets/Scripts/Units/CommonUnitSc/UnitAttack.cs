using System;
using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class UnitAttack : MonoBehaviour
{
    [SerializeField] UnitValues unitValues;

    [SerializeField] int projectileCode;

    public async UniTaskVoid Attack()
    {
        while(true)
        {
            if(!unitValues.IsAttacking || unitValues.IsDead) break;
            Debug.Log("Attacking");
            unitValues.GetUnitAnimator().SetTrigger(ConstStrings.UNIT_ANIMATOR_ATTACK);
            await UniTask.Delay(TimeSpan.FromSeconds(unitValues.UnitSO.TimeBetweenAttack), cancellationToken: unitValues.GetUnitStateController().GetTokenSource.Token);
        }
    }

    public void AnimEvent_CloseRangeAttack()
    {
        Transform target = unitValues.GetIsEnemy switch
        {
            true => unitValues.GetEnemySetTarget().GetCurrentTarget,
            _ => unitValues.GetGuardSetTarget().GetCurrentTarget,
        };

        if(target.TryGetComponent<IDamageable>(out var component))
        {
            component.TakeDamage(unitValues.UnitSO.AttackDamage + (int)UnityEngine.Random.Range(unitValues.PlusDamageRange.x, unitValues.PlusDamageRange.y), unitValues.GetDamageType);
        }
    }

    public void AnimEvent_LongRangeAttack()
    {
        var projectile = ProjectileObjectPool.Instance.GetProjectile(projectileCode);

        Transform target = unitValues.GetIsEnemy switch
        {
            true => unitValues.GetEnemySetTarget().GetCurrentTarget,
            _ => unitValues.GetGuardSetTarget().GetCurrentTarget,
        };

        projectile.SetValues(target, unitValues.GetProjectileOutPos, unitValues.UnitSO.AttackDamage, unitValues.GetDamageType);
    }
}
