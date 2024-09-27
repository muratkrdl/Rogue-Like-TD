using UnityEngine;

public class TowerUnitIdleState : ITowerUnitState
{
    public void EnterState(TowerUnitValues unitValues)
    {
        Debug.Log("Entering Idle");
    }

    public void ExitState(TowerUnitValues unitValues)
    {
        Debug.Log("Exiting Idle");
    }

    public void UpdateState(TowerUnitValues unitValues)
    {
        // eğer rangede varsa currenttarget yap ve saldırt

        Debug.Log("Updating Idle");
    }
}
