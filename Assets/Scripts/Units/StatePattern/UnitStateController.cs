using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class UnitStateController : MonoBehaviour
{
    [SerializeField] UnitValues unitValues;

    CancellationTokenSource cts = new();

    IUnitState currentState;

    public CancellationTokenSource GetTokenSource
    {
        get => cts;
    }

    public void StartFunc(int value)
    {
        currentState = value switch
        {
            0 => new EnemyIdleState(),
            1 => new GuardIdleState(),
            _ => new SpecialEnemyIdleState(),
        };

        currentState.EnterState(unitValues);
    }

    void Update() 
    {
        currentState.UpdateState(unitValues);
    }

    public void ChangeState(IUnitState newState)
    {
        currentState.ExitState(unitValues);
        currentState = newState;
        currentState.EnterState(unitValues);
    }

    public void ClearTokenSource()
    {
        cts.Cancel();
        cts = new();
    }

}
