using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackState : IUnitState
{
    public void EnterState(UnitValues unitValues)
    {
        Debug.Log("Entering Attack");
        unitValues.IsAttacking = true;
        unitValues.GetUnitAttack().Attack().Forget();
    }

    public void ExitState(UnitValues unitValues)
    {
        Debug.Log("Exiting Attack");
        unitValues.GetUnitAnimator().ResetTrigger("Attack");
        unitValues.GetUnitStateController().ClearTokenSource();
        unitValues.IsAttacking = false;
    }

    public void UpdateState(UnitValues unitValues)
    {
        Debug.Log("Updating Attack");

        if(Mathf.Abs(Vector2.Distance(unitValues.GetUnitSetTarget().GetCurrentTarget.position, 
        unitValues.transform.position)) > unitValues.EnemySO.AttackRange + .2f)
        {
            unitValues.GetUnitStateController().ChangeState(new EnemyIdleState());
        }
    }
}
