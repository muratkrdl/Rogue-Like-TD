using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvolvedBuildAnim : MonoBehaviour
{
    bool isBusy = false;

    public bool GetIsBusy
    {
        get
        {
            return isBusy;
        }
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
        GetComponent<Animator>().SetTrigger(ConstStrings.TOWER_LEVEL_UP);
    }

    public void PlayDestroyAnim()
    {
        GetComponent<Animator>().SetTrigger(ConstStrings.BUILD_TOWER_ANIM_DESTROY);
    }

}
