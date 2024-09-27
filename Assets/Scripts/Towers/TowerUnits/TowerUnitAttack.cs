using System;
using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class TowerUnitAttack : MonoBehaviour
{
    [SerializeField] TowerUnitValues towerUnitValues;

    public async UniTaskVoid Attack()
    {
        while(true)
        {
            if(!towerUnitValues.IsAttacking) break;
            Debug.Log("Attacking");
            towerUnitValues.GetTowerUnitAnimator().SetTrigger(ConstStrings.UNIT_ANIMATOR_ATTACK);
            await UniTask.Delay(TimeSpan.FromSeconds(towerUnitValues.GetTowerInfo.TimeBetweenAttack), cancellationToken: towerUnitValues.GetTowerUnitStateController().GetTokenSource.Token);
        }
    }

    public void AnimEvent_LongRangeAttack()
    {
        var projectile = ProjectileObjectPool.Instance.GetProjectile(towerUnitValues.GetTowerInfo.projectileCode);
        if(projectile != null) // CHECKPOOL
        {
            projectile.SetValues(towerUnitValues.GetTowerUnitSetTarget().GetCurrentTarget, towerUnitValues.GetProjectileOutPos,AllProjectileSOs.Instance.GetProjectiileSO(towerUnitValues.GetTowerInfo.projectileCode));
        }
        else // SPAWN
        {
            projectile = Instantiate(towerUnitValues.GetProjectilePrefab, towerUnitValues.GetProjectileOutPos.position, Quaternion.identity, 
            ProjectileObjectPool.Instance.GetInstantiatedObjParent(towerUnitValues.GetTowerInfo.projectileCode)).GetComponent<Projectile>();
            projectile.SetValues(towerUnitValues.GetTowerUnitSetTarget().GetCurrentTarget, towerUnitValues.GetProjectileOutPos, AllProjectileSOs.Instance.GetProjectiileSO(towerUnitValues.GetTowerInfo.projectileCode));

            ProjectileObjectPool.Instance.OnCreatedProjectileObj?.Invoke(this, new() { code = towerUnitValues.GetTowerInfo.projectileCode, createdObj = projectile } );
        }
    }
}
