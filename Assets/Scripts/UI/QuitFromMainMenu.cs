using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitFromMainMenu : MainMenuButton
{
    bool canInteract = true;

    public void OnClick_Quit()
    {
        if(!canInteract) return;
        canInteract = false;
        GameStateManager.Instance.PauseGame();
        FadeImageController.Instance.SetFadeImage(true);

        Invoke(nameof(InvokeForSceneChange), 1.6f);
    }

    void InvokeForSceneChange()
    {
        Application.Quit();
    }

    public override void InteractWithButton()
    {
        base.InteractWithButton();
        OnClick_Quit();
    }
}
