using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerShootPointKeeper : MonoBehaviour
{
    [SerializeField] TowerShootPoint[] towerShootPoints;

    public TowerShootPoint GetAvailablePoint()
    {
        TowerShootPoint returnTowerShootPoint = towerShootPoints[0];
        for (int i = 0; i < towerShootPoints.Length -1; i++)
        {
            if(towerShootPoints[i].attackerCount > towerShootPoints[i+1].attackerCount)
            {
                returnTowerShootPoint = towerShootPoints[i+1];
            }
        }
        returnTowerShootPoint.attackerCount += 1;
        return returnTowerShootPoint;
    }

}
