using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleAnimator : MonoBehaviour
{
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] Animator animator;

    [SerializeField] GetInputs getInputs;

    void Update()
    {
        animator.SetFloat(ConstStrings.PLAYER_ANIMATOR_X, getInputs.GetMoveInput.x);
        animator.SetFloat(ConstStrings.PLAYER_ANIMATOR_y, getInputs.GetMoveInput.y);
        animator.SetFloat(ConstStrings.PLAYER_ANIMATOR_SPEED, getInputs.GetMoveInput.sqrMagnitude);
        animator.SetFloat(ConstStrings.PLAYER_ANIMATOR_LASTX, getInputs.GetLastMoveDir.x);
        animator.SetFloat(ConstStrings.PLAYER_ANIMATOR_LASTY, getInputs.GetLastMoveDir.y);
    }

}
