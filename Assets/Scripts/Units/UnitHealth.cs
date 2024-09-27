using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitHealth : MonoBehaviour, IDamageable
{
    [SerializeField] UnitValues unitValues;

    int currenHealth;

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
        currenHealth -= amount;

        if(currenHealth <= 0)
        {
            unitValues.IsDead = true;
            unitValues.GetUnitMove().StopUnit();
            unitValues.GetUnitAnimator().SetTrigger(ConstStrings.UNIT_ANIMATOR_DEATH);
            IUnitState state;
            if(unitValues.GetIsEnemy)
                state = new EnemyIdleState();
            else
                state = new GuardIdleState();
            unitValues.GetUnitStateController().ChangeState(state);
        }
    }

}
