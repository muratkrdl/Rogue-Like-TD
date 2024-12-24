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

    public void PlaySFX()
    {
        SoundManager.Instance.PlaySound2D(ConstStrings.VINE);
    }
}
