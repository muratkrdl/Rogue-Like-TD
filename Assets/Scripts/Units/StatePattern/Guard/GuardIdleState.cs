using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardIdleState : IUnitState
{
    public void EnterState(UnitValues unitValues)
    {
        unitValues.IsChasing = false;
        
        Debug.Log("Entering Idle");
    }

    public void ExitState(UnitValues unitValues)
    {
        Debug.Log("Exiting Idle");
    }

    public void UpdateState(UnitValues unitValues)
    {
        if(unitValues.IsDead) return;

        // kule menziline düşman girince hareket ettir chasing i true yap

        Debug.Log("Updating Idle");
    }
}
