using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardWalkState : IUnitState
{
    public void EnterState(UnitValues unitValues)
    {
        unitValues.GetUnitSetTarget().ChangeCurrentTarget(GlobalUnitTargets.Instance.GetMainTower());
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
        
    }
}
