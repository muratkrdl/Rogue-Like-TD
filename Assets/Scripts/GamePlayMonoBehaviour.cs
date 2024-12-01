using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public abstract class GamePlayMonoBehaviour : MonoBehaviour
{
    [SerializeField] bool pauseable;

    protected bool GetPauseable
    {
        get => pauseable;
    }

    void OnDestroy() 
    {
        GameStateManager.Instance.OnPause -= GameStateManager_OnPause;
        GameStateManager.Instance.OnResume -= GameStateManager_OnResume;
    }

    public void GameStateManager_OnPause(object sender, EventArgs e)
    {
        enabled = false;
        PostPause();
    }

    public void GameStateManager_OnResume(object sender, EventArgs e)
    {
        enabled = true;
        PostResume();
    }

    protected virtual void PostPause() { }
    protected virtual void PostResume() { }

}
