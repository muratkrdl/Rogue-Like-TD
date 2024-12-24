using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneButton : MainMenuButton
{
    public override void InteractWithButton()
    {
        base.InteractWithButton();
        FadeImageController.Instance.SetFadeImage(true);
        GameStateManager.Instance.PauseGame();
        Invoke(nameof(InvokeLoadScene), 1.4f);
    }

    void InvokeLoadScene()
    {
        SceneManager.LoadScene(GetOpenMenuName);
    }
}
