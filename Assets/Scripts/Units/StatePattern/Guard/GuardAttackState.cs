using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardAttackState : IUnitState
{
    public void EnterState(UnitValues unitValues)
    {
        unitValues.GetUnitMove().LastDir = -(unitValues.transform.position - unitValues.GetGuardSetTarget().GetCurrentTarget.position).normalized / 5;
        unitValues.IsAttacking = true;
        unitValues.GetUnitAttack().Attack().Forget();
    }

    public void ExitState(UnitValues unitValues)
    {
        unitValues.GetUnitAnimator().ResetTrigger(ConstStrings.UNIT_ANIMATOR_ATTACK);
        unitValues.GetUnitStateController().ClearTokenSource();
        unitValues.IsAttacking = false;
    }

    public void UpdateState(UnitValues unitValues)
    {
        if(!unitValues.GetGuardSetTarget().TowerEnemyKeeper.ItemInList(unitValues.GetGuardSetTarget().GetCurrentTarget) || 
        (unitValues.GetGuardSetTarget().GetCurrentTarget.TryGetComponent<UnitValues>(out var component) && component.IsDead))
        {
            unitValues.IsChasing = false;
            unitValues.GetGuardSetTarget().ChangeCurrentTarget(unitValues.TowerBasePosition);
            unitValues.GetUnitStateController().ChangeState(new GuardWalkState());
        }
    }
}
