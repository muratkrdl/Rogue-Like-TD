using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardSetTarget : MonoBehaviour
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
        GetComponent<UnitStateController>().StartFunc(1);
    }

    public void SetNormalPos()
    {
        ChangeCurrentTarget(transform); // kuleden veri çekip oraya doğru yürüt
    }

    public void ChangeCurrentTarget(Transform changeTransform)
    {
        currentTarget = changeTransform;
        currentDestPos = changeTransform;
    }

}
