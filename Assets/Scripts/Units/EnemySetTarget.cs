using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySetTarget : MonoBehaviour
{
    [SerializeField] int startUnitStateCode;

    Transform currentTarget;
    Transform currentDestPos;

    public Transform GetCurrentTarget
    {
        get => currentTarget;
    }

    public Transform GetCurrentDestPos
    {
        get => currentDestPos;
    }

    public void SetCurrentTargetToMainTower()
    {
        ChangeCurrentTarget(GlobalUnitTargets.Instance.GetMainTower(), true);
    }

    public void ChangeCurrentTarget(Transform changeTransform, bool isTower)
    {
        currentTarget = changeTransform;
        if(isTower)
        {
            currentDestPos = changeTransform.GetComponent<TowerShootPointKeeper>().GetAvailablePoint().transform;
        }
        else
        {
            currentDestPos = changeTransform;
        }
    }
}
