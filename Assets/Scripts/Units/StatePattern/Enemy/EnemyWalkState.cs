using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class EnemyWalkState : IUnitState
{
    public void EnterState(UnitValues unitValues)
    {

    }

    public void ExitState(UnitValues unitValues)
    {

    }

    public void UpdateState(UnitValues unitValues)
    {
        if(!unitValues.GetEnemySetTarget().GetCurrentTarget.gameObject.activeSelf || 
        (unitValues.GetEnemySetTarget().GetCurrentTarget.TryGetComponent<UnitValues>(out var guard) && guard.IsDead))
        {
            unitValues.GetUnitStateController().ChangeState(new EnemyIdleState());
        }

        unitValues.GetUnitMove().MoveUnit();
        GlobalUnitTargets.Instance.CheckClosePlayerandTower(unitValues, unitValues.transform);

        float distanceBetweenTarget = Mathf.Abs(Vector2.Distance(unitValues.GetEnemySetTarget().GetCurrentDestPos.position, unitValues.transform.position));

        if(unitValues.IsChasing)
        {
            if(distanceBetweenTarget >= unitValues.UnitSO.AttackRange + 3.5f)
            {
                unitValues.GetUnitStateController().ChangeState(new EnemyIdleState());
            }
        }

        if(distanceBetweenTarget <= unitValues.UnitSO.AttackRange + .05f)
        {
            unitValues.GetUnitMove().StopUnit(false);
            unitValues.GetUnitStateController().ChangeState(new EnemyAttackState());
        }
    }
}
