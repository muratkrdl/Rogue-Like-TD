using System;
using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class TutorialEnemySpawner : MonoBehaviour
{
    [SerializeField] Transform enemySpawnPos;

    int goblinCode = 3;

    public void SpawnGoblin()
    {
        SpawnNewEnemy(goblinCode);
    }

    void SpawnNewEnemy(int code)
    {
        UnitValues enemy = EnemyObjectPool.Instance.GetEnemy(code);

        UnitSO unitSO = AllUnitInfoKeeper.Instance.GetEnemySOByMinute(enemy.GetHasLongRange);

        Transform spawnPos = enemySpawnPos;
        bool isGoingToRight = false;

        enemy.SetValues(spawnPos, unitSO, 0);
        enemy.IsGoingToRight = isGoingToRight;
    }
    
}
