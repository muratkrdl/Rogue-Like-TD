using UnityEngine;

public class TowerUnitIdleState : ITowerUnitState
{
    public void EnterState(TowerUnitValues unitValues)
    {
        unitValues.GetTowerUnitStateController().ClearTokenSource();

        unitValues.GetTowerUnitSetTarget().ClosestTarget();
    }

    public void ExitState(TowerUnitValues unitValues)
    {

    }

    public void UpdateState(TowerUnitValues unitValues)
    {
        if(!unitValues.GetTowerUnitSetTarget().GetCurrentTarget.CompareTag(TagManager.ENEMY))
        {
            unitValues.GetTowerUnitSetTarget().ClosestTarget();
            return;
        }

        unitValues.GetTowerUnitStateController().ChangeState(new TowerUnitAttackState());

    }
}
