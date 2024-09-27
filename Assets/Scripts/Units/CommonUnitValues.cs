using UnityEngine;

public abstract class CommonUnitValues : MonoBehaviour
{
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] Transform projectileOutPos;

    [SerializeField] UnitAnimator unitAnimator;
    [SerializeField] UnitMove unitMove;
    [SerializeField] UnitAttack unitAttack;
    [SerializeField] UnitStateController unitStateController;

    public UnitSO UnitSO { get; set; }

    public bool isEnemy;
    public bool IsChasing { get; set; }
    public bool IsAttacking { get; set; }

    public bool GetIsEnemy
    {
        get
        {
            return isEnemy;
        }
    }

    public GameObject GetProjectilePrefab
    {
        get
        {
            return projectilePrefab;
        }
    }
    public Transform GetProjectileOutPos
    {
        get
        {
            return projectileOutPos;
        }
    }

    public UnitAnimator GetUnitAnimator
    {
        get
        {
            return unitAnimator;
        }
    }
    public UnitMove GetUnitMove
    {
        get
        {
            return unitMove;
        }
    }
    public UnitAttack GetUnitAttack
    {
        get
        {
            return unitAttack;
        }
    }
    public UnitStateController GetUnitStateController
    {
        get
        {
            return unitStateController;
        }
    }
}
