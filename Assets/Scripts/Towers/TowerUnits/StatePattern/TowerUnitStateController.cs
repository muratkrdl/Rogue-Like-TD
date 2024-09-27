using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class TowerUnitStateController : MonoBehaviour
{
    [SerializeField] TowerUnitValues towerUnitValues;

    CancellationTokenSource cts = new();

    ITowerUnitState currentState = new TowerUnitIdleState();

    public CancellationTokenSource GetTokenSource
    {
        get
        {
            return cts;
        }
    }

    void Update() 
    {
        currentState.UpdateState(towerUnitValues);
    }

    public void ChangeState(ITowerUnitState newState)
    {
        currentState.ExitState(towerUnitValues);
        currentState = newState;
        currentState.EnterState(towerUnitValues);
    }

    public void ClearTokenSource()
    {
        cts.Cancel();
        cts = new();
    }

}
