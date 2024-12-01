using System.Collections;
using System.Collections.Generic;
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
            myAnimator.SetTrigger(ConstStrings.ANIM);
        else
            myAnimator.SetTrigger(ConstStrings.RESET);
    }

    public virtual void InteractWithButton() { /* */ }

}
