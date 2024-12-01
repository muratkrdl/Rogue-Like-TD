using System;
using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using TMPro;
using UnityEngine;

public class GameTimer : MonoBehaviour
{
    public static GameTimer Instance;

    [SerializeField] TextMeshProUGUI timerText;

    int currentSecond = 0;
    int currentMinute = 0;

    public int GetCurrentMinute
    {
        get => currentMinute;
    }
    public int GetCurrentSecond
    {
        get => currentSecond;
    }

    void Awake() 
    {
        Instance = this;
        UpdateTimerUI();
    }

    public void OnClick_StartTimer()
    {
        StartGameTimer().Forget();
    }

    async UniTaskVoid StartGameTimer()
    {
        while (true)
        {
            await UniTask.WaitUntil(() => !GameStateManager.Instance.GetIsGamePaused);
            await UniTask.Delay(TimeSpan.FromSeconds(1));
            await UniTask.WaitUntil(() => !GameStateManager.Instance.GetIsGamePaused);
            currentSecond++;
            if(currentSecond >= 60)
            {
                currentMinute++;
                currentSecond = 0;

                EnemySpawner.Instance.SetNewCharacters();
                if(currentMinute == 3)
                    EnemySpawner.Instance.SetCanSpawnMagical = true;
                else if(currentMinute == 6)
                    EnemySpawner.Instance.SetCanSpawnSpecial = true;
                else if(currentMinute == 7)
                    EnemySpawner.Instance.SetCanSpawnBoss = true;
            }

            UpdateTimerUI();
        }
    }

    void UpdateTimerUI()
    {
        timerText.text = currentMinute.ToString() + ":" + currentSecond.ToString("00");
    }

}
