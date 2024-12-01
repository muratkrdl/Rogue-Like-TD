using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public static EnemySpawner Instance;

    [SerializeField] Transform[] rightSpawnPos;
    [SerializeField] Transform[] leftSpawnPos;

    [SerializeField] float physicalSpawnRate;
    [SerializeField] float magicalSpawnRate;
    [SerializeField] float specialSpawnRate;
    [SerializeField] float bossSpawnRate;

    [SerializeField] int[] magicalDamageIndexCanbe;
    [SerializeField] int[] specialIndexCanbe;
    [SerializeField] int[] bossIndexCanbe;

    int spawnPhysicalIndex = 0;

    int[] currentEnemyPhysicalIndex = new int[3];
    int currentEnemyMagicalIndex;
    int currentEnemySpecialIndex;
    int currentBossIndex;

    bool canSpawnPhysical = false;
    bool canSpawnMagical = false;
    bool canSpawnSpecial = false;
    bool canSpawnBoss = false;

    public bool SetCanSpawnPhysical
    {
        set => canSpawnPhysical = value;
    }
    public bool SetCanSpawnMagical
    {
        set => canSpawnMagical = value;
    }
    public bool SetCanSpawnSpecial
    {
        set => canSpawnSpecial = value;
    }
    public bool SetCanSpawnBoss
    {
        set => canSpawnBoss = value;
    }

    void Awake() 
    {
        Instance = this;
    }

    void Start() 
    {
        currentEnemyPhysicalIndex[0] = 0;
        currentEnemyPhysicalIndex[1] = 3;
        currentEnemyPhysicalIndex[2] = 6;
        
        currentEnemyMagicalIndex = magicalDamageIndexCanbe[0];

        currentEnemySpecialIndex = specialIndexCanbe[0];

        currentBossIndex = bossIndexCanbe[0];

        SpawnPhysicalEnemy().Forget();
        SpawnMagicalEnemy().Forget();
        SpawnSpecialEnemy().Forget();
        SpawnBossEnemy().Forget();
    }

    public void SetNewCharacters()
    {
        for (int i = 0; i < currentEnemyPhysicalIndex.Length; i++)
        {
            int value = currentEnemyPhysicalIndex[i]; value++;
            if(value >= 9)
                value -= 9;
            currentEnemyPhysicalIndex[i] = value;
        }

        currentEnemyMagicalIndex = magicalDamageIndexCanbe[GameTimer.Instance.GetCurrentMinute % 3];
        
        if(currentEnemySpecialIndex == specialIndexCanbe[0])
            currentEnemySpecialIndex = specialIndexCanbe[1];
        else
            currentEnemySpecialIndex = specialIndexCanbe[0];
        
        currentBossIndex++;
        if(currentBossIndex > bossIndexCanbe.Last())
            currentBossIndex = bossIndexCanbe[0];
    }

    async UniTaskVoid SpawnPhysicalEnemy()
    {
        await UniTask.WaitUntil(() => canSpawnPhysical);
        while (true)
        {
            int spawnedPhysicalEnemy = 0;
            int spawnSide = UnityEngine.Random.Range(0, 2);
            await UniTask.WaitUntil(() => !GameStateManager.Instance.GetIsGamePaused);
            await UniTask.Delay(TimeSpan.FromSeconds(physicalSpawnRate));
            while(spawnedPhysicalEnemy < 4)
            {
                spawnedPhysicalEnemy++;
                await UniTask.Delay(TimeSpan.FromSeconds(.1f));
                SpawnNewEnemy(currentEnemyPhysicalIndex[spawnPhysicalIndex], spawnSide, false);
                spawnPhysicalIndex++;
                if(spawnPhysicalIndex > 2)
                    spawnPhysicalIndex = 0;
            }
        }
    }

    async UniTaskVoid SpawnMagicalEnemy()
    {
        await UniTask.WaitUntil(() => canSpawnMagical);
        while (true)
        {
            int spawnedMagicalEnemy = 0;
            int spawnSide = UnityEngine.Random.Range(0, 2);
            await UniTask.WaitUntil(() => !GameStateManager.Instance.GetIsGamePaused);
            await UniTask.Delay(TimeSpan.FromSeconds(magicalSpawnRate));
            while(spawnedMagicalEnemy < 2)
            {
                spawnedMagicalEnemy++;
                await UniTask.Delay(TimeSpan.FromSeconds(.1f));
                SpawnNewEnemy(currentEnemyMagicalIndex, spawnSide, false);
            }
        }
    }

    async UniTaskVoid SpawnSpecialEnemy()
    {
        await UniTask.WaitUntil(() => canSpawnSpecial);
        while (true)
        {
            int spawnedSpecialEnemy = 0;
            int spawnSide = UnityEngine.Random.Range(0, 2);
            await UniTask.WaitUntil(() => !GameStateManager.Instance.GetIsGamePaused);
            await UniTask.Delay(TimeSpan.FromSeconds(specialSpawnRate));
            while(spawnedSpecialEnemy < 2)
            {
                spawnedSpecialEnemy++;
                await UniTask.Delay(TimeSpan.FromSeconds(.1f));
                SpawnNewEnemy(currentEnemySpecialIndex, spawnSide, false);
            }
        }
    }

    async UniTaskVoid SpawnBossEnemy()
    {
        await UniTask.WaitUntil(() => canSpawnBoss);
        while (true)
        {
            int spawnSide = UnityEngine.Random.Range(0, 2);
            await UniTask.WaitUntil(() => !GameStateManager.Instance.GetIsGamePaused);
            SpawnNewEnemy(currentBossIndex, spawnSide, true);
            await UniTask.Delay(TimeSpan.FromSeconds(bossSpawnRate));
            currentBossIndex++;
            if(currentBossIndex > 18)
                    currentBossIndex = 14;
        }
    }

    void SpawnNewEnemy(int code, int spawnSideCode, bool isBoss)
    {
        var enemy = EnemyObjectPool.Instance.GetEnemy(code);

        UnitSO unitSO = AllUnitInfoKeeper.Instance.GetEnemySOByMinute(enemy.GetHasLongRange);

        Transform spawnPos;
        bool isGoingToRight = false;

        if(spawnSideCode == 0)
        {
            spawnPos = leftSpawnPos[UnityEngine.Random.Range(0, leftSpawnPos.Length)];
            isGoingToRight = true;
        }
        else
        {
            spawnPos = rightSpawnPos[UnityEngine.Random.Range(0, rightSpawnPos.Length)];
        }

        if(isBoss)
        {
            unitSO = AllUnitInfoKeeper.Instance.GetBossSOByMinute();
        }

        enemy.SetValues(spawnPos, unitSO, 0);
        enemy.IsGoingToRight = isGoingToRight;
    }

}
