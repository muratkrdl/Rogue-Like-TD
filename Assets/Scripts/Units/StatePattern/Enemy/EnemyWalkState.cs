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
        GlobalUnitTargets.Instance.CheckClosePlayerandTower(unitValues, unitValues.transform);

        float distanceBetweenTarget = Mathf.Abs(Vector2.Distance(unitValues.GetEnemySetTarget().GetCurrentDestPos.position, unitValues.transform.position));

        if(unitValues.IsChasing)
        {
            if(distanceBetweenTarget >= unitValues.UnitSO.AttackRange + 3.5f)
            {
                unitValues.GetUnitStateController().ChangeState(new EnemyIdleState());
            }
        }

        if(distanceBetweenTarget <= unitValues.UnitSO.AttackRange + .15f)
        {
            unitValues.GetUnitMove().StopUnit(false);
            unitValues.GetUnitStateController().ChangeState(new EnemyAttackState());
        }
        
        Debug.Log("Updating Walk");
    }
}
