using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardIdleState : IUnitState
{
    public void EnterState(UnitValues unitValues)
    {
        Debug.Log("Entering Idle");
    }

    public void ExitState(UnitValues unitValues)
    {
        Debug.Log("Exiting Idle");
    }

    public void UpdateState(UnitValues unitValues)
    {
        Debug.Log("Updating Idle");
    
        GlobalUnitTargets.Instance.CheckClosePlayerandTower(unitValues, unitValues.transform);
    }
}
