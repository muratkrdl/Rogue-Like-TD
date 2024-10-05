using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class UnitAnimator : MonoBehaviour
{
    [SerializeField] Animator animator;

    [SerializeField] UnitValues unitValues;

    void Update()
    {
        if(!unitValues.GetNavMeshAgent().isStopped)
        {
            animator.SetFloat(ConstStrings.UNIT_ANIMATOR_SPEED, unitValues.GetUnitMove().LastDir.sqrMagnitude);
        }
        animator.SetFloat(ConstStrings.UNIT_ANIMATOR_LASTX, unitValues.GetUnitMove().LastDir.x);
        animator.SetFloat(ConstStrings.UNIT_ANIMATOR_LASTY, unitValues.GetUnitMove().LastDir.y);
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
