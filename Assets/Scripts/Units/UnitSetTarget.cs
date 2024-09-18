using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSetTarget : MonoBehaviour
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
        SetCurrentTargetToMainTower();
    }

    public void SetCurrentTargetToMainTower()
    {
        currentTarget = GlobalUnitTargets.Instance.GetMainTower();
        currentDestPos = GlobalUnitTargets.Instance.GetMainTower().GetComponent<TowerShootPointKeeper>().GetAvailablePoint().transform;
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
