using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenMenuButton : MainMenuButton
{
    
    public override void InteractWithButton()
    {
        MainMenuManager.Instance.OpenMenu(GetOpenMenuName);
    }

}
