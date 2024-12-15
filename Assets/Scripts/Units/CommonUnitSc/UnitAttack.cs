using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class UnitAttack : MonoBehaviour
{
    [SerializeField] UnitValues unitValues;

    [SerializeField] int projectileCode;

    CancellationTokenSource cts = new();

    public async UniTaskVoid Attack()
    {
        while(true)
        {
            if(!unitValues.IsAttacking || unitValues.IsDead) break;
            await UniTask.WaitUntil(() => !GameStateManager.Instance.GetIsGamePaused, cancellationToken: cts.Token);
            unitValues.GetUnitAnimator().SetTrigger(ConstStrings.UNIT_ANIMATOR_ATTACK);
            float calculatedDelay = unitValues.UnitSO.TimeBetweenAttack;
            if(!unitValues.GetIsEnemy)
            {
                calculatedDelay -= unitValues.UnitSO.TimeBetweenAttack * GetComponentInParent<TowerInfoKeeper>().GetExtraAttackSpeedFromBloodRain + (float)PermanentSkillSystem.Instance.GetPermanentSkillSO(9).Value/100;
            }
            await UniTask.Delay(TimeSpan.FromSeconds(calculatedDelay), cancellationToken: unitValues.GetUnitStateController().GetTokenSource.Token);
        }
    }

    public void AnimEvent_CloseRangeAttack()
    {
        if(GameStateManager.Instance.GetIsGamePaused) return;

        Transform target = unitValues.GetIsEnemy switch
        {
            true => unitValues.GetEnemySetTarget().GetCurrentTarget,
            _ => unitValues.GetGuardSetTarget().GetCurrentTarget,
        };


        float calculatedDamage = unitValues.UnitSO.AttackDamage + UnityEngine.Random.Range(unitValues.PlusDamageRange.x, unitValues.PlusDamageRange.y);
        
        if(!unitValues.GetIsEnemy)
        {
            calculatedDamage += calculatedDamage * (GetComponentInParent<TowerInfoKeeper>().GetExtraDamageFromDarkAura + (float)PermanentSkillSystem.Instance.GetPermanentSkillSO(10).Value/100);
        }

        if(target.TryGetComponent<IDamageable>(out var component))
        {
            component.SetHP(calculatedDamage, unitValues.GetDamageType);
        }
    }

    public void AnimEvent_LongRangeAttack()
    {
        Transform target = unitValues.GetIsEnemy switch
        {
            true => unitValues.GetEnemySetTarget().GetCurrentTarget,
            _ => unitValues.GetGuardSetTarget().GetCurrentTarget,
        };

        if(unitValues.GetIsEnemy)
        {
            if(Mathf.Abs(Vector2.Distance(transform.localPosition, 
            unitValues.GetEnemySetTarget().GetCurrentDestPos.position)) >
            unitValues.UnitSO.AttackRange + .5f) return;
        }

        var projectile = ProjectileObjectPool.Instance.GetProjectile(projectileCode);

        projectile.SetValues(target, unitValues.GetProjectileOutPos, unitValues.UnitSO.AttackDamage, unitValues.GetDamageType, false);
    }

    void OnDestroy() 
    {
        cts.Cancel();
    }

}
