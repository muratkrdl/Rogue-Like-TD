using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButton : MonoBehaviour
{
    [SerializeField] Animator myAnimator;

    [SerializeField] string openMenuName;

    public string GetOpenMenuName
    {
        get => openMenuName;
    }

    public void OnObjHitted(bool value)
    {
        if(value)
        {
            myAnimator.SetTrigger(ConstStrings.ANIM);
            SoundManager.Instance.PlaySound2DVolume(ConstStrings.BUTTONSHOW, 1.5f);
        }
        else
        {
            myAnimator.SetTrigger(ConstStrings.RESET);
        }
    }

    public virtual void InteractWithButton() 
    {
        SoundManager.Instance.PlaySound2DVolume(ConstStrings.BUTTONCLICK, 1.5f);
    }

}
