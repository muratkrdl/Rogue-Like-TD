using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdleState : IUnitState
{
    public void EnterState(UnitValues unitValues)
    {
        unitValues.GetUnitSetTarget().SetCurrentTargetToMainTower();
        unitValues.GetUnitSetTarget().CheckClosePlayerandTower();
        unitValues.GetUnitStateController().ChangeState(new EnemyWalkState());
    }

    public void ExitState(UnitValues unitValues)
    {
        Debug.Log("Exiting Idle");
    }

    public void UpdateState(UnitValues unitValues)
    {
        Debug.Log("Updating Idle");
    }
}
