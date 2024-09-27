using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerUnitAnimator : MonoBehaviour
{
    [SerializeField] Animator animator;

    [SerializeField] TowerUnitValues towerUnitValues;

    void Update()
    {
        animator.SetFloat(ConstStrings.UNIT_ANIMATOR_LASTX, towerUnitValues.GetTowerUnitSetTarget().GetLastDir.x);
        animator.SetFloat(ConstStrings.UNIT_ANIMATOR_LASTY, towerUnitValues.GetTowerUnitSetTarget().GetLastDir.y);
    }

    public void SetTrigger(string name)
    {
        animator.SetTrigger(name);
    }
    
    public void ResetTrigger(string name)
    {
        animator.ResetTrigger(name);
    }
}
