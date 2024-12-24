using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenMenuButton : MainMenuButton
{
    public override void InteractWithButton()
    {
        base.InteractWithButton();
        MainMenuManager.Instance.OpenMenu(GetOpenMenuName);
    }
}
