using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleAnimator : MonoBehaviour
{
    [SerializeField] Animator animator;

    [SerializeField] GetInputs getInputs;

    void Update()
    {
        animator.SetFloat(ConstStrings.UNIT_ANIMATOR_X, getInputs.GetMoveInput.x);
        animator.SetFloat(ConstStrings.UNIT_ANIMATOR_y, getInputs.GetMoveInput.y);
        animator.SetFloat(ConstStrings.UNIT_ANIMATOR_SPEED, getInputs.GetMoveInput.sqrMagnitude);
        animator.SetFloat(ConstStrings.UNIT_ANIMATOR_LASTX, getInputs.GetLastMoveDir.x);
        animator.SetFloat(ConstStrings.UNIT_ANIMATOR_LASTY, getInputs.GetLastMoveDir.y);
    }

}
