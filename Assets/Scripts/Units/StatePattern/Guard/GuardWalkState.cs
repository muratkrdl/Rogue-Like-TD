using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GuardWalkState : IUnitState
{
    public void EnterState(UnitValues unitValues)
    {

    }

    public void ExitState(UnitValues unitValues)
    {
    
    }

    public void UpdateState(UnitValues unitValues)
    {
        unitValues.GetUnitMove().MoveUnit();

        float distanceBetweenTarget = Mathf.Abs(Vector2.Distance(unitValues.GetGuardSetTarget().
        GetCurrentTarget.transform.position, unitValues.transform.position));

        if(unitValues.IsChasing)
        {
            if(!unitValues.GetGuardSetTarget().TowerEnemyKeeper.ItemInList(unitValues.GetGuardSetTarget().GetCurrentTarget) || 
            (unitValues.GetGuardSetTarget().GetCurrentTarget.TryGetComponent<UnitValues>(out var component) && component.IsDead))
            {
                unitValues.GetGuardSetTarget().ChangeCurrentTarget(unitValues.TowerBasePosition);
                unitValues.IsChasing = false;
            }
            else if(distanceBetweenTarget <= unitValues.UnitSO.AttackRange + .15f)
            {
                unitValues.GetUnitMove().StopUnit(false);
                unitValues.GetUnitStateController().ChangeState(new GuardAttackState());
            }
        }
        else
        {
            if(distanceBetweenTarget <= unitValues.UnitSO.AttackRange + .01f)
            {
                unitValues.GetUnitMove().StopUnit(false);
                unitValues.GetUnitStateController().ChangeState(new GuardIdleState());
            }
        }
    }
}
