using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerUnitValues : MonoBehaviour
{
    [SerializeField] GameObject parent;

    [SerializeField] Transform projectileOutPos;

    [SerializeField] TowerUnitAnimator towerUnitAnimator;
    [SerializeField] TowerUnitAttack towerUnitAttack;
    [SerializeField] TowerUnitStateController towerUnitStateController;
    [SerializeField] TowerUnitSetTarget towerUnitSetTarget;
    [SerializeField] TowerEnemyKeeper towerEnemyKeeper;

    public TowerInfoSo GetTowerInfo => GetComponentInParent<TowerInfoKeeper>().GetCurrentTowerInfo;
    public Transform GetProjectileOutPos
    {
        get
        {
            return projectileOutPos;
        }
    }

    bool isChasing = false;
    bool isAttacking = false;

    public bool IsChasing
    {
        get
        {
            return isChasing;
        }
        set
        {
            isChasing = value;
        }
    }
    public bool IsAttacking
    {
        get
        {
            return isAttacking;
        }
        set
        {
            isAttacking = value;
        }
    }

    public TowerUnitAnimator GetTowerUnitAnimator()
    {
        return towerUnitAnimator;
    }
    public TowerUnitSetTarget GetTowerUnitSetTarget()
    {
        return towerUnitSetTarget;
    }
    public TowerUnitAttack GetTowerUnitAttack()
    {
        return towerUnitAttack;
    }
    public TowerUnitStateController GetTowerUnitStateController()
    {
        return towerUnitStateController;
    }
    public TowerEnemyKeeper GetTowerEnemyKeeper()
    {
        return towerEnemyKeeper;
    }

}
