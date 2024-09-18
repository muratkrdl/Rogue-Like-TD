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
            if(!unitValues.IsAttacking) break;
            Debug.Log("Attacking");
            unitValues.GetUnitAnimator().SetTrigger("Attack");
            await UniTask.Delay(TimeSpan.FromSeconds(unitValues.UnitSO.TimeBetweenAttack), cancellationToken: unitValues.GetUnitStateController().GetTokenSource.Token);
        }
    }

    public void AnimEvent_CloseRangeAttack()
    {
        if(unitValues.GetUnitSetTarget().GetCurrentTarget.TryGetComponent<IDamageable>(out var component))
        {
            component.TakeDamage(unitValues.UnitSO.AttackDamage);
        }
    }

    public void AnimEvent_LongRangeAttack()
    {
        // spawn projectile
        var projectile = ProjectileObjectPool.Instance.GetProjectile(projectileCode);
        if(projectile != null)
        {
            projectile.SetValues(unitValues.GetUnitSetTarget().GetCurrentTarget, unitValues.GetProjectileOutPos,AllProjectileSOs.Instance.GetProjectiileSO(projectileCode));
        }
        else
        {
            projectile = Instantiate(unitValues.GetProjectilePrefab, unitValues.GetProjectileOutPos.position, Quaternion.identity, 
            ProjectileObjectPool.Instance.GetInstantiatedObjParent(projectileCode)).GetComponent<Projectile>();
            projectile.SetValues(unitValues.GetUnitSetTarget().GetCurrentTarget, unitValues.GetProjectileOutPos, AllProjectileSOs.Instance.GetProjectiileSO(projectileCode));

            ProjectileObjectPool.Instance.OnCreatedProjectileObj?.Invoke(this, new() { code = projectileCode, createdObj = projectile } );
        }
    }
}
