using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvolvedBuildAnim : MonoBehaviour
{
    bool isBusy = false;

    public bool GetIsBusy
    {
        get => isBusy;
    }
    
    public void AnimEvent_IsBusyFalse()
    {
        isBusy = false;
    }
    
    public void AnimEvent_IsBusyTrue()
    {
        isBusy = true;
    }

    public void PlayBuildAnim()
    {
        GetComponent<Animator>().SetTrigger(ConstStrings.ANIM);
    }

    public void PlayDestroyAnim()
    {
        GetComponent<Animator>().SetTrigger(ConstStrings.BUILD_TOWER_ANIM_DESTROY);
    }

}
