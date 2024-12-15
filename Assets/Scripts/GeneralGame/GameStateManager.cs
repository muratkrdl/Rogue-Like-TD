using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    public static GameStateManager Instance;

    public EventHandler OnPause;
    public EventHandler OnResume;

    bool isGamePaused;

    public bool GetIsGamePaused
    {
        get => isGamePaused;
    }

    void Awake() 
    {
        Instance = this;
    }

    void Start() 
    {
        Time.timeScale = 1;
    }

    public void PauseGame()
    {
        if(GameOverMenu.Instance.IsGameOver) return;
        isGamePaused = true;
        OnPause?.Invoke(this, EventArgs.Empty);
    }

    public void ResumeGame()
    {
        if(GameOverMenu.Instance.IsGameOver) return;
        isGamePaused = false;
        OnResume?.Invoke(this, EventArgs.Empty);
    }

}
