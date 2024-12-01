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
            await UniTask.WaitUntil(() => !GameStateManager.Instance.GetIsGamePaused);
            await UniTask.Delay(TimeSpan.FromSeconds(towerInfoKeeper.GetCurrentTowerInfo.attackDelay * .0833f));
            AttackFunc();

            if(!towerUnitValues.IsAttacking || towerInfoKeeper.GetCurrentTowerCode == -1) break;
            
            float a = towerInfoKeeper.GetExtraAttackSpeedFromBloodRain + (float)PermanentSkillSystem.Instance.GetPermanentSkillSO(9).Value/100;
            await UniTask.Delay(TimeSpan.FromSeconds(towerUnitValues.GetTowerInfo.TimeBetweenAttack - (towerUnitValues.GetTowerInfo.TimeBetweenAttack * a)), 
            cancellationToken: towerUnitValues.GetTowerUnitStateController().GetTokenSource.Token);
        }
    }

    void AttackFunc()
    {
        if(towerUnitValues.GetTowerInfo == null || towerUnitValues.GetTowerUnitSetTarget().CheckTargetToBase()) return;

        var projectile = ProjectileObjectPool.Instance.GetProjectile(towerUnitValues.GetTowerInfo.projectileCode);

        float calculatedDamage = UnityEngine.Random.Range(towerUnitValues.GetTowerInfo.BaseDamageRange.x, towerUnitValues.GetTowerInfo.BaseDamageRange.y);

        projectile.SetValues(towerUnitValues.GetTowerUnitSetTarget().GetCurrentTarget, 
        towerUnitValues.GetProjectileOutPos, 
        calculatedDamage + (calculatedDamage * (towerInfoKeeper.GetExtraDamageFromDarkAura + (float)PermanentSkillSystem.Instance.GetPermanentSkillSO(10).Value/100)),
        towerInfoKeeper.GetCurrentTowerInfo.damageType);
    }

}
