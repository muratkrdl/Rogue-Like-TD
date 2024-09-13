using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitValues : MonoBehaviour
{
    [SerializeField] UnitSO enemySO;
    [SerializeField] GameObject projectilePrefab;

    [SerializeField] UnitAnimator unitAnimator;
    [SerializeField] UnitMove unitMove;
    [SerializeField] UnitSetTarget unitSetTarget;
    [SerializeField] UnitAttack unitAttack;
    [SerializeField] UnitStateController unitStateController;

    public UnitSO EnemySO
    {
        get
        {
            return enemySO;
        }
        set
        {
            enemySO = value;
        }
    }
    public GameObject GetProjectilePrefab
    {
        get
        {
            return projectilePrefab;
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

    public UnitAnimator GetUnitAnimator()
    {
        return unitAnimator;
    }
    public UnitMove GetUnitMove()
    {
        return unitMove;
    }
    public UnitSetTarget GetUnitSetTarget()
    {
        return unitSetTarget;
    }
    public UnitAttack GetUnitAttack()
    {
        return unitAttack;
    }
    public UnitStateController GetUnitStateController()
    {
        return unitStateController;
    }
}
