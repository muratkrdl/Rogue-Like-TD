using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VineAnimEvent : MonoBehaviour
{
    [SerializeField] VineDamager[] vineDamagers;

    public void AnimEvent_VineDamager()
    {
        foreach(var item in vineDamagers)
        {
            item.ClearList();
        }
    }
}
