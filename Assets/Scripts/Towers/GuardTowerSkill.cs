using System;
using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class GuardTowerSkill : MonoBehaviour
{
    [SerializeField] TowerEnemyKeeper towerEnemyKeeper;

    [SerializeField] int reSpawnCoolDown;

    [SerializeField] Transform spawnPos;
    [SerializeField] Transform baseTowerPos;

    [SerializeField] UnitValues currentUnit;

    void Start() 
    {
        GlobalUnitTargets.Instance.OnAnGuardDead += GlobalUnitTargets_OnAnGuardDead;
    }

    void GlobalUnitTargets_OnAnGuardDead(object sender, GlobalUnitTargets.OnAnUnitDeadEventArgs e)
    {
        if(e.deadUnit == currentUnit)
        {
            RespawnUnit().Forget();
        }
    }

    async UniTaskVoid RespawnUnit()
    {
        await UniTask.Delay(TimeSpan.FromSeconds(reSpawnCoolDown));
        if(GetComponentInParent<TowerInfoKeeper>().GetCurrentTowerCode == -1) return;
        UpdateUnitCode();
    }

    public void UpdateUnitCode()
    {
        currentUnit.SetValues(spawnPos, AllUnitInfoKeeper.Instance.GetGuardInfo(0), 1);
        currentUnit.UnitSO = AllUnitInfoKeeper.Instance.GetGuardInfo(0); // current dakikadan çek
        currentUnit.PlusDamageRange = GetComponentInParent<TowerInfoKeeper>().GetCurrentTowerInfo.BaseDamageRange;
        currentUnit.GetUnitStateController().StartFunc(1);
    }

    public void SetSpawnPos()
    {
        currentUnit.GetNavMeshAgent().Warp(spawnPos.position);
    }

    void OnDestroy() 
    {
        GlobalUnitTargets.Instance.OnAnGuardDead -= GlobalUnitTargets_OnAnGuardDead;
    }

}
