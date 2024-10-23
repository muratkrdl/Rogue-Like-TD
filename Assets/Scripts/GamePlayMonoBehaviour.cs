using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GamePlayMonoBehaviour : MonoBehaviour
{
    [SerializeField] bool pauseable;

    public bool GetPauseable
    {
        get => pauseable;
    }

    void OnDestroy() 
    {
        if(!pauseable) return;

        GameStateManager.Instance.OnPause -= GameStateManager_OnPause;
        GameStateManager.Instance.OnResume -= GameStateManager_OnResume;
    }

    public void GameStateManager_OnPause(object sender, EventArgs e)
    {
        if(!pauseable) return;

        enabled = false;
        PostPause();
    }

    public void GameStateManager_OnResume(object sender, EventArgs e)
    {
        if(!pauseable) return;

        enabled = true;
        PostResume();
    }

    protected virtual void PostPause() { }
    protected virtual void PostResume() { }

}
