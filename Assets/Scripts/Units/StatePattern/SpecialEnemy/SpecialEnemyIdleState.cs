using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialEnemyIdleState : IUnitState
{
    public void EnterState(UnitValues unitValues)
    {
        if(unitValues.IsDead) return;
        
        unitValues.GetEnemySetTarget().SetCurrentTargetToMainTower();
        unitValues.GetUnitStateController().ChangeState(new SpecialEnemyWalkState());
    }

    public void ExitState(UnitValues unitValues)
    {

    }

    public void UpdateState(UnitValues unitValues)
    {

    }

}
