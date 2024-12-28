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

    [SerializeField] Vector3 playerRespawnPos;

    [SerializeField] Transform enemyWaitPos;

    [SerializeField] bool canEnemyAttackTower;

    public Vector3 GetPlayerRespawnPos
    {
        get => playerRespawnPos;
    }
    public Transform GetEnemyWaitPos
    {
        get => enemyWaitPos;
    }

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
        !GetPlayerTarget().GetComponent<PlayerHealth>().IsDead)
        {
            unitValues.IsChasing = true;
            unitValues.GetEnemySetTarget().ChangeCurrentTarget(GetPlayerTarget(), false);
        }
        else
        {
            foreach (var item in guardUnitsPos)
            {
                if(!item.gameObject.activeInHierarchy || item.GetComponent<UnitValues>().IsWaiting || item.GetComponent<UnitValues>().IsDead) continue;

                if(Mathf.Abs(Vector2.Distance(unit.position, item.position)) <= unitValues.UnitSO.AttackRange + 3.5f)
                {
                    if(unitValues.IsGoingToRight && item.position.x > 0) continue;
                    else if(!unitValues.IsGoingToRight && item.position.x < 0) continue;
                    unitValues.GetEnemySetTarget().ChangeCurrentTarget(item, false);
                    unitValues.IsChasing = true;
                    break;
                }
            }

            //if(unitValues.IsChasing ||!canEnemyAttackTower) return;
            //
            //foreach(var item in GetTowersPos())
            //{
            //    if(item.GetComponent<TowerInfoKeeper>().GetCurrentTowerCode == -1) continue;

            //    if(unitValues.IsGoingToRight && (unit.position.x - item.position.x > 0 || item.position.x > 0)) continue;
            //    else if(!unitValues.IsGoingToRight && (unit.position.x - item.position.x < 0 || item.position.x < 0)) continue;

            //    if(Mathf.Abs(Vector2.Distance(unit.position, item.position)) <= unitValues.UnitSO.AttackRange + 3.5f)
            //    {
            //        Transform setTarget;
            //        bool isTower = true;

            //        if(Mathf.Abs(Vector2.Distance(unit.position, mainTower.position)) < Mathf.Abs(Vector2.Distance(unit.position, item.position)))
            //        {
            //            setTarget = mainTower;
            //        }
            //        else
            //        {
            //            setTarget = item;
            //            if(setTarget.TryGetComponent<TowerInfoKeeper>(out var infoKeeper))
            //            {
            //                if(infoKeeper.GetCurrentTowerCode == 2 || 
            //                infoKeeper.GetCurrentTowerCode == 8 || 
            //                infoKeeper.GetCurrentTowerCode == 9)
            //                {
            //                    if(setTarget.GetComponent<LevelUpTower>().GetChoosenUnitAnimator.gameObject.activeInHierarchy &&
            //                    !setTarget.GetComponent<LevelUpTower>().GetChoosenUnitAnimator.GetComponent<UnitValues>().IsDead)
            //                    {
            //                        setTarget = setTarget.GetComponent<LevelUpTower>().GetChoosenUnitAnimator.gameObject.transform;
            //                        isTower = false;
            //                    }
            //                }
            //            }
            //        }

            //        unitValues.GetEnemySetTarget().ChangeCurrentTarget(setTarget, isTower);
            //        unitValues.IsChasing = true;
            //        break;
            //    }
            //}
        }
    }

    public bool CanPlayerUseSkill()
    {
        return !GameStateManager.Instance.GetIsGamePaused && !playerTarget.GetComponent<PlayerHealth>().IsDead && playerTarget.gameObject.activeSelf;
    }

}
