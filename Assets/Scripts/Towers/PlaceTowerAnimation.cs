using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceTowerAnimation : MonoBehaviour
{
    [SerializeField] Animator animator;

    [SerializeField] TowerInfo[] towerInfos;

    public void ChangeAnimation()
    {
        animator.SetBool(ConstStrings.PLACE_TOWER_ANIMATOR_ISIN, !animator.GetBool(ConstStrings.PLACE_TOWER_ANIMATOR_ISIN));
    }

    public void CloseAnimation()
    {
        if(animator.GetBool(ConstStrings.PLACE_TOWER_ANIMATOR_ISIN))
        {
            animator.SetBool(ConstStrings.PLACE_TOWER_ANIMATOR_ISIN, false);
        }
    }

    public void AnimEvent_Close()
    {
        foreach (var item in towerInfos)
        {
            item.SetInfoParentObject(false);
        }
    }

}
