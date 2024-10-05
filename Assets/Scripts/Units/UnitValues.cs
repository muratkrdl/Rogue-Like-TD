using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class UnitValues : MonoBehaviour
{
    [SerializeField] UnitSO unitSO;
    [SerializeField] Transform projectileOutPos;

    [SerializeField] NavMeshAgent navMeshAgent;
    [SerializeField] UnitAnimator unitAnimator;
    [SerializeField] UnitMove unitMove;
    [SerializeField] UnitAttack unitAttack;
    [SerializeField] UnitStateController unitStateController;
    [SerializeField] UnitHealth unitHealth;

    [SerializeField] EnemySetTarget enemySetTarget;
    [SerializeField] GuardSetTarget guardSetTarget;

    [SerializeField] bool isEnemy;

    public UnitSO UnitSO
    {
        get
        {
            return unitSO;
        }
        set
        {
            unitSO = value;
            unitHealth.CurrenHealth = unitSO.MaxHealth;
        }
    }
    public Transform GetProjectileOutPos
    {
        get
        {
            return projectileOutPos;
        }
    }
    public bool GetIsEnemy
    {
        get
        {
            return isEnemy;
        }
    }

    bool isChasing = false;
    bool isAttacking = false;
    bool isDead = false;

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
    public bool IsDead
    {
        get
        {
            return isDead;
        }
        set
        {
            isDead = value;
        }
    }

    public NavMeshAgent GetNavMeshAgent()
    {
        return navMeshAgent;
    }
    public UnitAnimator GetUnitAnimator()
    {
        return unitAnimator;
    }
    public UnitMove GetUnitMove()
    {
        return unitMove;
    }
    public EnemySetTarget GetEnemySetTarget()
    {
        return enemySetTarget;
    }
    public GuardSetTarget GetGuardSetTarget()
    {
        return guardSetTarget;
    }
    public UnitAttack GetUnitAttack()
    {
        return unitAttack;
    }
    public UnitStateController GetUnitStateController()
    {
        return unitStateController;
    }
    public UnitHealth GetUnitHealth()
    {
        return unitHealth;
    }
}
