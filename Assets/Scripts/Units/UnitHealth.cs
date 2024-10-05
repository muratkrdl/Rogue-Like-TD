using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class UnitHealth : MonoBehaviour, IDamageable
{
    [SerializeField] UnitValues unitValues;

    int currenHealth = 100;

    public int CurrenHealth
    {
        get
        {
            return currenHealth;
        }
        set
        {
            currenHealth = value;
        }
    }

    public void TakeDamage(int amount)
    {
        if(unitValues.IsDead) return; 

        currenHealth -= amount;

        if(currenHealth <= 0)
        {
            unitValues.IsDead = true;
            unitValues.GetUnitMove().StopSuddenly();
            unitValues.GetUnitAnimator().SetTrigger(ConstStrings.UNIT_ANIMATOR_DEATH);
            IUnitState state;
            if(unitValues.GetIsEnemy)
            {
                state = new EnemyIdleState();
                GetComponent<CircleCollider2D>().enabled = false;
                GlobalUnitTargets.Instance.OnAnEnemyDead?.Invoke(this, new() { deadEnemy = unitValues } );
            }
            else
            {
                state = new GuardIdleState();
            }
            unitValues.GetUnitStateController().ChangeState(state);
        }
    }

}
