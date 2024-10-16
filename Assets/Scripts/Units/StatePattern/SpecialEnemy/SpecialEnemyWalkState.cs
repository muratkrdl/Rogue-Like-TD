using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialEnemyWalkState : IUnitState
{
    public void EnterState(UnitValues unitValues)
    {

    }

    public void ExitState(UnitValues unitValues)
    {

    }

    public void UpdateState(UnitValues unitValues)
    {
        if(!unitValues.GetEnemySetTarget().GetCurrentTarget.gameObject.activeSelf)
        {
            unitValues.GetUnitStateController().ChangeState(new SpecialEnemyIdleState());
        }

        unitValues.GetUnitMove().MoveUnit();

        GlobalUnitTargets.Instance.CheckClosePlayerandTower(unitValues, unitValues.transform);

        float distanceBetweenTarget = Mathf.Abs(Vector2.Distance(unitValues.GetEnemySetTarget().GetCurrentDestPos.position, unitValues.transform.position));

        if(unitValues.IsChasing)
        {
            if(distanceBetweenTarget >= unitValues.UnitSO.AttackRange + 3.5f)
            {
                unitValues.GetUnitStateController().ChangeState(new SpecialEnemyIdleState());
            }
        }

        if(distanceBetweenTarget <= .3f)
        {
            // special Anim and dead
            unitValues.GetUnitHealth().TakeDamage(999, DamageType.truedamage);
        } 
    }
}
