using System;
using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class UnitAttack : MonoBehaviour
{
    [SerializeField] UnitValues unitValues;

    public async UniTaskVoid Attack()
    {
        while(true)
        {
            if(!unitValues.IsAttacking) break;
            Debug.Log("Attacking");
            unitValues.GetUnitAnimator().SetTrigger("Attack");
            await UniTask.Delay(TimeSpan.FromSeconds(unitValues.EnemySO.TimeBetweenAttack), cancellationToken: unitValues.GetUnitStateController().GetTokenSource.Token);
        }
    }

    public void AnimEvent_CloseRangeAttack()
    {
        if(unitValues.GetUnitSetTarget().GetCurrentTarget.TryGetComponent<IDamageable>(out var component))
        {
            component.TakeDamage(unitValues.EnemySO.AttackDamage);
        }
    }

    public void AnimEvent_LongRangeAttack()
    {
        // spawn projectile
        
    }
}
