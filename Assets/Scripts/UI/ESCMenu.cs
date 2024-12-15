using System;
using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ESCMenu : MonoBehaviour
{
    public static ESCMenu Instance;

    [SerializeField] Animator myAnimator;

    [SerializeField] TextMeshProUGUI resumeTimerText;

    void Awake() 
    {
        Instance = this;    
    }

    public void SetValues()
    {
        SetESCMenu(true);
    }

    public void OnClick_PauseButton()
    {
        if(GameStateManager.Instance.GetIsGamePaused || GameOverMenu.Instance.IsGameOver) return;
        GameStateManager.Instance.PauseGame();
        SetESCMenu(true);
    }

    public void OnClick_Resume()
    {
        if(!GameStateManager.Instance.GetIsGamePaused) return;
        SetESCMenu(false);
        myAnimator.SetTrigger(ConstStrings.ANIM1);
        ResumeTimer().Forget();
    }

    async UniTaskVoid ResumeTimer()
    {
        await UniTask.Delay(TimeSpan.FromSeconds(.5f));
        int timer = 3;
        resumeTimerText.text = timer.ToString();
        while(timer > 0)
        {
            await UniTask.Delay(TimeSpan.FromSeconds(1));
            timer--;
            resumeTimerText.text = timer.ToString();
        }

        SetESCMenu(false);
        GameStateManager.Instance.ResumeGame();
    }

    public void OnClick_Quit()
    {
        FadeImageController.Instance.SetFadeImage(true);
        Invoke(nameof(InvokeForSceneChange), 1.25f);
    }

    void InvokeForSceneChange()
    {
        SceneManager.LoadScene(0);
    }

    void SetESCMenu(bool value)
    {
        if(value)
            myAnimator.SetTrigger(ConstStrings.ANIM);
        else
            myAnimator.SetTrigger(ConstStrings.RESET);
    }

}
