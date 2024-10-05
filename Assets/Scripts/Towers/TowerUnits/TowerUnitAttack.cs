using System;
using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class TowerUnitAttack : MonoBehaviour
{
    [SerializeField] float delay;

    [SerializeField] TowerUnitValues towerUnitValues;

    TowerInfoKeeper towerInfoKeeper;

    void Start() 
    {
        towerInfoKeeper = GetComponentInParent<TowerInfoKeeper>();
    }

    public async UniTaskVoid Attack()
    {
        while(true)
        {
            await UniTask.WaitUntil(() => !towerInfoKeeper.GetEvolvedBuildAnim().GetIsBusy);
            if(!towerUnitValues.IsAttacking || towerInfoKeeper.GetCurrentTowerCode == -1) break;
            towerUnitValues.GetTowerUnitAnimator().SetTrigger(ConstStrings.UNIT_ANIMATOR_ATTACK);
            await UniTask.Delay(TimeSpan.FromSeconds(towerInfoKeeper.GetCurrentTowerInfo.attackDelay * .0833f));
            InvokeAttack();

            Debug.Log("Attacking");

            await UniTask.Delay(TimeSpan.FromSeconds(towerUnitValues.GetTowerInfo.TimeBetweenAttack), cancellationToken: towerUnitValues.GetTowerUnitStateController().GetTokenSource.Token);
        }
    }

    void InvokeAttack()
    {
        var projectile = ProjectileObjectPool.Instance.GetProjectile(towerUnitValues.GetTowerInfo.projectileCode);
        if(projectile != null) // CHECKPOOL
        {
            projectile.SetValues(towerUnitValues.GetTowerUnitSetTarget().GetCurrentTarget, 
            towerUnitValues.GetProjectileOutPos, 
            UnityEngine.Random.Range(towerUnitValues.GetTowerInfo.BaseDamageRange.x, towerUnitValues.GetTowerInfo.BaseDamageRange.y));
        }
        else // SPAWN
        {
            projectile = Instantiate(ProjectileObjectPool.Instance.GetProjectilePrefab(towerUnitValues.GetTowerInfo.projectileCode), towerUnitValues.GetProjectileOutPos.position, Quaternion.identity, 
            ProjectileObjectPool.Instance.GetInstantiatedObjParent(towerUnitValues.GetTowerInfo.projectileCode)).GetComponent<Projectile>();
            projectile.SetValues(towerUnitValues.GetTowerUnitSetTarget().GetCurrentTarget, 
            towerUnitValues.GetProjectileOutPos, 
            UnityEngine.Random.Range(towerUnitValues.GetTowerInfo.BaseDamageRange.x, towerUnitValues.GetTowerInfo.BaseDamageRange.y));

            ProjectileObjectPool.Instance.OnCreatedProjectileObj?.Invoke(this, new() { code = towerUnitValues.GetTowerInfo.projectileCode, createdObj = projectile } );
        }
    }

}
