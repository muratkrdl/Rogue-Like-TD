using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalUnitTargets : MonoBehaviour
{
    public static GlobalUnitTargets Instance;
    
    [SerializeField] Transform[] towersPos;
    [SerializeField] Transform mainTower;
    [SerializeField] Transform playerTarget;

    void Awake() 
    {
        Instance = this;    
    }

    public Transform[] GetTowersPos()
    {
        return towersPos;
    }

    public Transform GetMainTower()
    {
        return mainTower;
    }

    public Transform GetPlayerTarget()
    {
        return playerTarget;
    }

    public void CheckClosePlayerandTower(UnitValues unitValues, Transform unit)
    {
        if(unitValues.IsChasing) return;
        
        if(Mathf.Abs(Vector2.Distance(unit.position, GetPlayerTarget().position)) <= unitValues.UnitSO.AttackRange + 2)
        {
            unitValues.GetUnitSetTarget().ChangeCurrentTarget(GetPlayerTarget(), false);
            unitValues.IsChasing = true;
        }
        else
        {
            foreach(var item in GetTowersPos())
            {
                if(item.GetComponent<TowerInfoKeeper>().GetCurrentTowerCode == -1) continue;
                if(Mathf.Abs(Vector2.Distance(unit.position, item.position)) <= unitValues.UnitSO.AttackRange + 2)
                {
                    Debug.Log(item);
                    unitValues.IsChasing = true;
                    unitValues.GetUnitSetTarget().ChangeCurrentTarget(item, true);
                    break;
                }
            }
        }
    }

}
