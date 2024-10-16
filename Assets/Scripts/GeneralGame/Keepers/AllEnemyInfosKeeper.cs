using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllEnemyInfosKeeper : MonoBehaviour
{
    public static AllEnemyInfosKeeper Instance;

    [SerializeField] UnitSO[] enemySOsCloseRange;
    [SerializeField] UnitSO[] enemySOsLongRange;

    void Awake() 
    {
        Instance = this;
    }

    public UnitSO GetEnemySOByMinute(bool longRange)
    {
        if(longRange)
            return enemySOsLongRange[GameTimer.Instance.GetCurrentMinute];
        else
            return enemySOsCloseRange[GameTimer.Instance.GetCurrentMinute];
    }

}
