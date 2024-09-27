using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardWalkState : IUnitState
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

        float distanceBetweenTarget = Mathf.Abs(Vector2.Distance(unitValues.GetGuardSetTarget().
        GetCurrentDestPos.transform.position, unitValues.transform.position));

        if(unitValues.IsChasing)
        {
            if(distanceBetweenTarget >= unitValues.UnitSO.AttackRange + 2f)
            {
                unitValues.GetGuardSetTarget().SetNormalPos();
                unitValues.IsChasing = false;
            }
            else if(distanceBetweenTarget <= unitValues.UnitSO.AttackRange + .375f)
            {
                unitValues.GetUnitMove().StopUnit();
                unitValues.GetUnitStateController().ChangeState(new GuardAttackState());
            }
        }
        else
        {
            if(distanceBetweenTarget <= unitValues.UnitSO.AttackRange + .375f)
            {
                unitValues.GetUnitMove().StopUnit();
                unitValues.GetUnitStateController().ChangeState(new GuardIdleState());
            }
        }

        Debug.Log("Updating Walk");
    }
}
