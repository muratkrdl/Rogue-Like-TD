using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerDeadPanel : MonoBehaviour
{
    public static PlayerDeadPanel Instance;

    public EventHandler<OnDeadTimerUpdateEventArgs> OnDeadTimerUpdate;
    public class OnDeadTimerUpdateEventArgs : EventArgs
    {
        public int amount;
    }

    [SerializeField] Animator myAnimator;

    [SerializeField] TextMeshProUGUI deadTimerText;

    void Awake() 
    {
        Instance = this;    
    }

    void Start() 
    {
        OnDeadTimerUpdate += PlayerDeadPanel_OnDeadTimerUpdate;
    }

    void PlayerDeadPanel_OnDeadTimerUpdate(object sender, OnDeadTimerUpdateEventArgs e)
    {
        deadTimerText.text = e.amount.ToString();
    }

    public void SetPanel(bool value)
    {
        if(value)
            myAnimator.SetTrigger(ConstStrings.ANIM);
        else
            myAnimator.SetTrigger(ConstStrings.RESET);
        
        deadTimerText.gameObject.SetActive(value);
    }

    void OnDestroy() 
    {
        OnDeadTimerUpdate -= PlayerDeadPanel_OnDeadTimerUpdate;
    }

}
