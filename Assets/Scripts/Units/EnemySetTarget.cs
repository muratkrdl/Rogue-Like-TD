using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySetTarget : MonoBehaviour
{
    Transform currentTarget;
    Transform currentDestPos;

    public Transform GetCurrentTarget
    {
        get
        {
            return currentTarget;
        }
    }

    public Transform GetCurrentDestPos
    {
        get
        {
            return currentDestPos;
        }
    }

    void Start() 
    {
        GetComponent<UnitStateController>().StartFunc(0);
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
