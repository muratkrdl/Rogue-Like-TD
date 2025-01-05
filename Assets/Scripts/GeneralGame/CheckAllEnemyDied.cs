using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class CheckAllEnemyDied : MonoBehaviour
{
    CancellationTokenSource cts = new();

    public async UniTaskVoid AllEnemyDied()
    {
        await UniTask.WaitUntil(() => CheckAllEnemyDiedFunc(), cancellationToken: cts.Token);

        // GameOver
        GameOverMenu.Instance.GameOver(true);
    }

    bool CheckAllEnemyDiedFunc()
    {
        for(int i = 0; i < 18; i++)
        {
            if(!EnemyObjectPool.Instance.CheckAllEnemyDied(i))
            {
                return false;
            }
        }

        return true;
    }

    void OnDestroy() 
    {
        cts?.Cancel();
    }

}
