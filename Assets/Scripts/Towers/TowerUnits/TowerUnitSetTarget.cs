using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerUnitSetTarget : MonoBehaviour
{
    [SerializeField] Transform baseTarget;

    [SerializeField] TowerUnitValues towerUnitValues;

    [SerializeField] Transform origin;

    Transform currentTarget;

    Vector2 lastDir = Vector2.down;

    public Vector2 GetLastDir
    {
        get => new (Mathf.Clamp(lastDir.x, -1, 1), Mathf.Clamp(lastDir.y, -1, 1f));
    }

    public Transform GetCurrentTarget
    {
        get => currentTarget;
    }

    void Start() 
    {
        ChangeCurrentTarget(baseTarget);

        towerUnitValues.GetTowerEnemyKeeper().OnEnemyListKeeperChanged += TowerEnemyKeeper_OnEnemyListKeeperChanged;
    }

    void TowerEnemyKeeper_OnEnemyListKeeperChanged(object sender, TowerEnemyKeeper.OnEnemyListKeeperChangedEventArgs e)
    {
        if(e.isIn && !towerUnitValues.IsChasing)
        {
            ChangeCurrentTarget(e.enemyTransform);
        }
        else if(!e.isIn && e.enemyTransform == currentTarget)
        {
            ClosestTarget();
        }
    }

    void Update() 
    {
        lastDir = (currentTarget.position - origin.position).normalized;
        
        if(MathF.Abs(lastDir.x) > Mathf.Abs(lastDir.y))
            lastDir.y = 0;
        else
            lastDir.x = 0;

        if(Mathf.Abs(lastDir.x) > Mathf.Epsilon && towerUnitValues.GetTowerInfo.towercode <= 3)
        {
            transform.localScale = new(-Mathf.Sign(lastDir.x), transform.localScale.y, transform.localScale.z);
        }
    }

    public void ChangeCurrentTarget(Transform changeTransform)
    {
        currentTarget = changeTransform;
    }

    public void ClosestTarget()
    {
        Transform choosenTarget;
        if(towerUnitValues.GetTowerEnemyKeeper().GetEnemiesInRangeList.Count > 0)
        {
            choosenTarget = towerUnitValues.GetTowerEnemyKeeper().GetClosestEnemy();
        }
        else
        {
            choosenTarget = baseTarget;
        }

        ChangeCurrentTarget(choosenTarget);
    }

    public void SetTargetToBaseTarget()
    {
        ChangeCurrentTarget(baseTarget);
    }

    void OnDestroy() 
    {
        towerUnitValues.GetTowerEnemyKeeper().OnEnemyListKeeperChanged -= TowerEnemyKeeper_OnEnemyListKeeperChanged;
    }

    public bool CheckTargetToBase()
    {
        return currentTarget == baseTarget;
    }

}
