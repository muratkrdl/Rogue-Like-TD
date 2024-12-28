using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using TMPro;
using UnityEngine;

public class GameTimer : MonoBehaviour
{
    public static GameTimer Instance;

    [SerializeField] TextMeshProUGUI timerText;

    CancellationTokenSource cts = new();

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
            await UniTask.WaitUntil(() => !GameStateManager.Instance.GetIsGamePaused, cancellationToken: cts.Token);
            await UniTask.Delay(TimeSpan.FromSeconds(1));
            await UniTask.WaitUntil(() => !GameStateManager.Instance.GetIsGamePaused);
            currentSecond++;
            if(currentSecond >= 60)
            {
                currentMinute++;
                currentSecond = 0;

                EnemySpawner.Instance.SetNewCharacters();
                if(currentMinute <= 6)
                {
                    if(currentMinute == 2)
                        EnemySpawner.Instance.SetCanSpawnMagical = true;
                    else if(currentMinute == 4)
                        EnemySpawner.Instance.SetCanSpawnSpecial = true;
                    else if(currentMinute == 6)
                        EnemySpawner.Instance.SetCanSpawnBoss = true;
                }
            }

            UpdateTimerUI();
        }
    }

    void UpdateTimerUI()
    {
        timerText.text = currentMinute.ToString() + ":" + currentSecond.ToString("00");
    }

    void OnDestroy() 
    {
        cts.Cancel();
    }

}
