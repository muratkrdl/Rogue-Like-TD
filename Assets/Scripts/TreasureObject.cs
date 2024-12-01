using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureObject : MonoBehaviour
{
    [SerializeField] Animator myAnimator;

    bool isAwailable = false;

    public bool GetIsAvaliable
    {
        get => isAwailable;
    }

    public void SetValues(Vector3 pos)
    {
        isAwailable = false;
        transform.position = pos;
    }

    public void ResetTreasureObj()
    {
        myAnimator.SetTrigger(ConstStrings.RESET);
        transform.position = new(111,111);
        isAwailable = true;
    }

}
