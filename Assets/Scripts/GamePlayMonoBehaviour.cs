using System;
using UnityEngine;

public abstract class GamePlayMonoBehaviour : MonoBehaviour
{
    [SerializeField] bool pauseable;

    protected bool GetPauseable
    {
        get => pauseable;
    }

    protected void SubscribeToEvents()
    {
        GameStateManager.Instance.OnPause += GameStateManager_OnPause;
        GameStateManager.Instance.OnResume += GameStateManager_OnResume;
    }

    void GameStateManager_OnPause(object sender, EventArgs e)
    {
        PostPause();
    }

    void GameStateManager_OnResume(object sender, EventArgs e)
    {
        PostResume();
    }

    protected virtual void PostPause() { /* */ }
    protected virtual void PostResume() { /* */ }

    protected void UnSubscribeToEvents() 
    {
        GameStateManager.Instance.OnPause -= GameStateManager_OnPause;
        GameStateManager.Instance.OnResume -= GameStateManager_OnResume;
    }

}
