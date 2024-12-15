using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardIdleState : IUnitState
{
    public void EnterState(UnitValues unitValues)
    {
        unitValues.IsChasing = false;

        if(unitValues.GetGuardSetTarget().GetCurrentTarget != unitValues.TowerBasePosition)
        {
            unitValues.GetGuardSetTarget().ChangeCurrentTarget(unitValues.TowerBasePosition);
            unitValues.GetUnitStateController().ChangeState(new GuardWalkState());
        }

        unitValues.GetUnitMove().LastDir = -(unitValues.transform.position - unitValues.GetGuardSetTarget().GetCurrentTarget.position).normalized / 5;
    }

    public void ExitState(UnitValues unitValues)
    {
    }

    public void UpdateState(UnitValues unitValues)
    {
        if(unitValues.IsDead) return;

        if(unitValues.GetGuardSetTarget().TowerEnemyKeeper.GetEnemiesInRangeList.Count > 0)
        {
            unitValues.IsChasing = true;
            unitValues.GetGuardSetTarget().ChangeCurrentTarget(unitValues.GetGuardSetTarget().TowerEnemyKeeper.GetClosestEnemy());
        }

        if(Vector2.Distance(unitValues.GetGuardSetTarget().GetCurrentTarget.position, unitValues.transform.position) > unitValues.UnitSO.AttackRange + .06f)
        {
            unitValues.GetUnitStateController().ChangeState(new GuardWalkState());
        }
    }
}
