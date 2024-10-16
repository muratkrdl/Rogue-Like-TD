using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllUnitInfoKeeper : MonoBehaviour
{
    public static AllUnitInfoKeeper Instance;

    [SerializeField] UnitSO[] enemyInfosClose;
    [SerializeField] UnitSO[] enemyInfosLong;
    [SerializeField] UnitSO[] guardInfos;

    void Awake() 
    {
        Instance = this;    
    }

    public UnitSO GetEnemyInfo(int currentMinute, int code)
    {
        if(code == 0)
            return enemyInfosClose[currentMinute];
        else
            return enemyInfosLong[currentMinute];
    }

    public UnitSO GetGuardInfo(int currentMinute)
    {
        return guardInfos[currentMinute];
    }

}
