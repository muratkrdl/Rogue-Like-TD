using System;
using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class TowerUnitAttack : MonoBehaviour
{
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
            AttackFunc();

            if(!towerUnitValues.IsAttacking || towerInfoKeeper.GetCurrentTowerCode == -1) break;
            
            await UniTask.Delay(TimeSpan.FromSeconds(towerUnitValues.GetTowerInfo.TimeBetweenAttack), cancellationToken: towerUnitValues.GetTowerUnitStateController().GetTokenSource.Token);
        }
    }

    void AttackFunc()
    {
        if(towerUnitValues.GetTowerInfo == null) return;

        var projectile = ProjectileObjectPool.Instance.GetProjectile(towerUnitValues.GetTowerInfo.projectileCode);

        projectile.SetValues(towerUnitValues.GetTowerUnitSetTarget().GetCurrentTarget, 
        towerUnitValues.GetProjectileOutPos, 
        UnityEngine.Random.Range(towerUnitValues.GetTowerInfo.BaseDamageRange.x, towerUnitValues.GetTowerInfo.BaseDamageRange.y),
        towerInfoKeeper.GetCurrentTowerInfo.damageType);
    }

}
