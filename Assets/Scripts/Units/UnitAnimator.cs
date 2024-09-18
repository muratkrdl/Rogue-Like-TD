using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitAnimator : MonoBehaviour
{
    [SerializeField] Animator animator;

    [SerializeField] UnitValues unitValues;

    void Update()
    {
        animator.SetFloat("Speed", unitValues.GetUnitMove().LastDir.sqrMagnitude);
        animator.SetFloat("LastX", unitValues.GetUnitMove().LastDir.x);
        animator.SetFloat("LastY", unitValues.GetUnitMove().LastDir.y);
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
