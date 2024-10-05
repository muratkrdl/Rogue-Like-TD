using UnityEngine;

public class TowerUnitIdleState : ITowerUnitState
{
    public void EnterState(TowerUnitValues unitValues)
    {
        unitValues.GetTowerUnitStateController().ClearTokenSource();

        unitValues.GetTowerUnitSetTarget().ClosestTarget();

        Debug.Log("Entering Idle");
    }

    public void ExitState(TowerUnitValues unitValues)
    {
        Debug.Log("Exiting Idle");
    }

    public void UpdateState(TowerUnitValues unitValues)
    {
        Debug.Log("Updating Idle");

        if(!unitValues.GetTowerUnitSetTarget().GetCurrentTarget.CompareTag(TagManager.ENEMY))
        {
            unitValues.GetTowerUnitSetTarget().ClosestTarget();
            return;
        }            

        unitValues.GetTowerUnitStateController().ChangeState(new TowerUnitAttackState());

    }
}
