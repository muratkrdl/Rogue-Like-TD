using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeImageController : MonoBehaviour
{
    public static FadeImageController Instance;

    [SerializeField] Animator myAnimator;

    void Awake() 
    {
        Instance = this;
    }

    public void SetFadeImage(bool value)
    {
        if(value)
            myAnimator.SetTrigger(ConstStrings.ANIM);
        else
            myAnimator.SetTrigger(ConstStrings.RESET);
    }

    public void AnimEvent_CloseSFX()
    {
        SoundManager.Instance.PlaySound2DVolume(ConstStrings.FADEPANELCLOSE, .5f);
    }

    public void AnimEvent_OpenSFX()
    {
        SoundManager.Instance.PlaySound2DVolume(ConstStrings.FADEPANELOPEN, .85f);
    }

}
