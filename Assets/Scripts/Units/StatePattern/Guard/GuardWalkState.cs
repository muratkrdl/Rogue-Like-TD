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
        Debug.Log("Updating Walk");
    }
}
