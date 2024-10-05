using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackState : IUnitState
{
    public void EnterState(UnitValues unitValues)
    {
        Debug.Log("Entering Attack");
        unitValues.IsAttacking = true;
        unitValues.GetUnitAttack().Attack().Forget();
    }

    public void ExitState(UnitValues unitValues)
    {
        Debug.Log("Exiting Attack");
        unitValues.GetUnitAnimator().ResetTrigger(ConstStrings.UNIT_ANIMATOR_ATTACK);
        unitValues.GetUnitStateController().ClearTokenSource();
        unitValues.IsAttacking = false;
    }

    public void UpdateState(UnitValues unitValues)
    {
        Debug.Log("Updating Attack");

        unitValues.GetUnitMove().LastDir = -(unitValues.transform.position - unitValues.GetEnemySetTarget().GetCurrentTarget.position).normalized / 5;

        if(Mathf.Abs(Vector2.Distance(unitValues.GetEnemySetTarget().GetCurrentDestPos.position, unitValues.transform.position)) >= unitValues.UnitSO.AttackRange + 3.5f)
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
