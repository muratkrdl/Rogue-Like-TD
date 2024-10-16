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
            if(towerShootPoints[i].AttackerCount > towerShootPoints[i+1].AttackerCount)
            {
                returnTowerShootPoint = towerShootPoints[i+1];
            }
        }
        returnTowerShootPoint.AttackerCount += 1;
        return returnTowerShootPoint;
    }

}
