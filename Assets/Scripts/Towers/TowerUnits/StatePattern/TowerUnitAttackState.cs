using UnityEngine;

public class TowerUnitAttackState : ITowerUnitState
{
    public void EnterState(TowerUnitValues unitValues)
    {
        Debug.Log("Entering Attack");

        unitValues.IsAttacking = true;
        unitValues.GetTowerUnitAttack().Attack().Forget();
    }

    public void ExitState(TowerUnitValues unitValues)
    {
        unitValues.GetTowerUnitAnimator().ResetTrigger(ConstStrings.UNIT_ANIMATOR_ATTACK);
        unitValues.GetTowerUnitStateController().ClearTokenSource();
        unitValues.IsAttacking = false;

        Debug.Log("Exiting Attack");
    }

    public void UpdateState(TowerUnitValues unitValues)
    {
        Debug.Log("Updating Attack");
    }
}
