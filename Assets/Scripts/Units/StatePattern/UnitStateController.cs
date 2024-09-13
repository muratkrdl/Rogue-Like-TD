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
        get
        {
            return cts;
        }
    }

    void Start() 
    {
        currentState = new EnemyIdleState();
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
