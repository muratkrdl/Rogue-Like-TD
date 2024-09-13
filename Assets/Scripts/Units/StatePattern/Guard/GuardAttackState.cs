using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardAttackState : IUnitState
{
    public void EnterState(UnitValues unitValues)
    {
        Debug.Log("Entering Attack");
    }

    public void ExitState(UnitValues unitValues)
    {
        Debug.Log("Exiting Attack");
    }

    public void UpdateState(UnitValues unitValues)
    {
        Debug.Log("Updating Attack");
    }
}
