using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllUnitInfoKeeper : MonoBehaviour
{
    public static AllUnitInfoKeeper Instance;

    [SerializeField] UnitSO[] bossInfos;

    [SerializeField] UnitSO[] enemyInfosClose;
    [SerializeField] UnitSO[] enemyInfosLong;
    [SerializeField] UnitSO[] guardInfos;

    void Awake() 
    {
        Instance = this;    
    }

    public UnitSO GetEnemySOByMinute(bool longRange)
    {
        if(longRange)
            return enemyInfosLong[GameTimer.Instance.GetCurrentMinute];
        else
            return enemyInfosClose[GameTimer.Instance.GetCurrentMinute];
    }

    public UnitSO GetBossSOByMinute()
    {
        return bossInfos[GameTimer.Instance.GetCurrentMinute]; // -6
    }

    public UnitSO GetGuardInfo(int currentMinute)
    {
        return guardInfos[currentMinute];
    }

}
