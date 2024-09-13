using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWalkState : IUnitState
{
    public void EnterState(UnitValues unitValues)
    {
        Debug.Log("Entering Walk");
    }

    public void ExitState(UnitValues unitValues)
    {
        Debug.Log("Exiting Walk");
    }

    public void UpdateState(UnitValues unitValues)
    {
        unitValues.GetUnitMove().MoveUnit();
        unitValues.GetUnitSetTarget().CheckClosePlayerandTower();

        float distanceBetweenTarget = Mathf.Abs(Vector2.Distance(unitValues.GetUnitSetTarget().
        GetCurrentTarget.transform.position, unitValues.transform.position));

        if(unitValues.IsChasing)
        {
            if(distanceBetweenTarget >= unitValues.EnemySO.AttackRange + 4.5f)
            {
                unitValues.GetUnitSetTarget().SetCurrentTargetToMainTower();
                unitValues.IsChasing = false;
            }
        }

        if(distanceBetweenTarget <= unitValues.EnemySO.AttackRange + .75f)
        {
            unitValues.GetUnitMove().StopUnit();
            unitValues.GetUnitStateController().ChangeState(new EnemyAttackState());
        }
        
        Debug.Log("Updating Walk");
    }
}
