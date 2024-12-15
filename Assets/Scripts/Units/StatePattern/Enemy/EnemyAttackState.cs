using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackState : IUnitState
{
    public void EnterState(UnitValues unitValues)
    {
        unitValues.IsAttacking = true;
        unitValues.GetUnitAttack().Attack().Forget();
    }

    public void ExitState(UnitValues unitValues)
    {
        unitValues.GetUnitAnimator().ResetTrigger(ConstStrings.UNIT_ANIMATOR_ATTACK);
        unitValues.GetUnitAnimator().ResetTrigger(ConstStrings.RESET);
        unitValues.GetUnitStateController().ClearTokenSource();
        unitValues.IsAttacking = false;
    }

    public void UpdateState(UnitValues unitValues)
    {
        unitValues.GetUnitMove().LastDir = -(unitValues.transform.position - unitValues.GetEnemySetTarget().GetCurrentTarget.position).normalized / 5;

        if(Mathf.Abs(Vector2.Distance(unitValues.GetEnemySetTarget().GetCurrentDestPos.position, unitValues.transform.position)) >= unitValues.UnitSO.AttackRange + .5f ||
        !unitValues.GetEnemySetTarget().GetCurrentTarget.gameObject.activeInHierarchy || 
        (unitValues.GetEnemySetTarget().GetCurrentTarget.TryGetComponent<TowerInfoKeeper>(out var component1) && component1.GetCurrentTowerCode == -1) ||
        (unitValues.GetEnemySetTarget().GetCurrentTarget.TryGetComponent<UnitValues>(out var component2) && (component2.IsWaiting || component2.IsDead)) ||
        (unitValues.GetEnemySetTarget().GetCurrentTarget.TryGetComponent<PlayerHealth>(out var component3) && component3.IsDead))
        {
            unitValues.GetUnitStateController().ChangeState(new EnemyIdleState());
        }

        if(unitValues.GetEnemySetTarget().GetCurrentTarget.TryGetComponent<TowerInfoKeeper>(out var component))
        {
            if(component.GetCurrentTowerCode == -1)
            {
                unitValues.GetUnitStateController().ChangeState(new EnemyIdleState());
            }
        }
    }
}
