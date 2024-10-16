using System;
using UnityEngine;

public class GlobalUnitTargets : MonoBehaviour
{
    public static GlobalUnitTargets Instance;

    public EventHandler<OnAnUnitDeadEventArgs> OnAnEnemyDead;
    public EventHandler<OnAnUnitDeadEventArgs> OnAnGuardDead;
    public class OnAnUnitDeadEventArgs : EventArgs
    {
        public UnitValues deadUnit;
    }
    
    [SerializeField] Transform[] towersPos;
    [SerializeField] Transform[] guardUnitsPos;
    [SerializeField] Transform mainTower;
    [SerializeField] Transform playerTarget;

    public Transform enemyWaitPos;
    public Transform guardWaitPos;

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
        
        if(Mathf.Abs(Vector2.Distance(unit.position, GetPlayerTarget().position)) <= unitValues.UnitSO.AttackRange + 2.2f &&
        GetPlayerTarget().gameObject.activeSelf && 
        !GetPlayerTarget().GetComponent<PlayerHealth>().GetIsDead)
        {
            unitValues.IsChasing = true;
            unitValues.GetEnemySetTarget().ChangeCurrentTarget(GetPlayerTarget(), false);
        }
        else
        {
            foreach (var item in guardUnitsPos)
            {
                if(!item.gameObject.activeInHierarchy || item.GetComponent<UnitValues>().IsWaiting) continue;

                if(Mathf.Abs(Vector2.Distance(unit.position, item.position)) <= unitValues.UnitSO.AttackRange + 3.5f)
                {
                    unitValues.GetEnemySetTarget().ChangeCurrentTarget(item, false);
                    unitValues.IsChasing = true;
                    break;
                }
            }

            if(unitValues.IsChasing) return;
            
            foreach(var item in GetTowersPos())
            {
                if(item.GetComponent<TowerInfoKeeper>().GetCurrentTowerCode == -1) continue;

                if(unitValues.IsGoingToRight && (unit.position.x - item.position.x > 0 || item.position.x > 0)) continue;
                else if(!unitValues.IsGoingToRight && (unit.position.x - item.position.x < 0 || item.position.x < 0)) continue;

                if(Mathf.Abs(Vector2.Distance(unit.position, item.position)) <= unitValues.UnitSO.AttackRange + 3.5f)
                {
                    Transform setTarget;
                    bool isTower = true;

                    if(Mathf.Abs(Vector2.Distance(unit.position, mainTower.position)) < Mathf.Abs(Vector2.Distance(unit.position, item.position)))
                    {
                        setTarget = mainTower;
                    }
                    else
                    {
                        setTarget = item;

                        // if(item.GetComponent<TowerInfoKeeper>().GetCurrentTowerCode == 2 || 
                        // item.GetComponent<TowerInfoKeeper>().GetCurrentTowerCode == 8 || 
                        // item.GetComponent<TowerInfoKeeper>().GetCurrentTowerCode == 9)
                        // {
                        //     if(item.GetComponent<TowerInfoKeeper>().GetCurrentTowerCode == 2)
                        //     {
                        //         UnitValues unitTower = item.GetChild(5).GetChild(0).GetComponentInChildren<UnitValues>();
                        //         if(!unitTower.IsWaiting)
                        //             setTarget = unitTower.transform;
                        //     }
                        //     else
                        //     {
                        //         UnitValues unitTower = item.GetChild(5).GetChild(1).GetComponentInChildren<UnitValues>();
                        //         if(!unitTower.IsWaiting)
                        //             setTarget = unitTower.transform;
                        //     }
                        //     isTower = false;
                        // }
                    }

                    unitValues.GetEnemySetTarget().ChangeCurrentTarget(setTarget, isTower);
                    unitValues.IsChasing = true;
                    break;
                }
            }
        }
    }

}
