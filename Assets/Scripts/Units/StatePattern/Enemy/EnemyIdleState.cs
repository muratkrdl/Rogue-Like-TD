using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdleState : IUnitState
{
    public void EnterState(UnitValues unitValues)
    {
        unitValues.IsChasing = false;
        if(unitValues.IsDead) return;
        unitValues.GetEnemySetTarget().SetCurrentTargetToMainTower();
        unitValues.GetUnitStateController().ChangeState(new EnemyWalkState());
    }

    public void ExitState(UnitValues unitValues)
    {
        
    }

    public void UpdateState(UnitValues unitValues)
    {

    }
}
