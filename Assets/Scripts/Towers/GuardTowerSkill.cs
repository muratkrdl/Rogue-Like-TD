using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class GuardTowerSkill : MonoBehaviour
{
    [SerializeField] int reSpawnCoolDown;

    [SerializeField] Transform spawnPos;

    [SerializeField] UnitValues currentUnit;

    CancellationTokenSource cts = new();

    void Start() 
    {
        GlobalUnitTargets.Instance.OnAnGuardDead += GlobalUnitTargets_OnAnGuardDead;
    }

    void GlobalUnitTargets_OnAnGuardDead(object sender, GlobalUnitTargets.OnAnUnitDeadEventArgs e)
    {
        if(e.deadUnit == currentUnit)
        {
            StartCoroutine(nameof(RespawnUnit));
        }
    }

    IEnumerator RespawnUnit()
    {
        float a = reSpawnCoolDown;
        while(a > 0)
        {
            yield return new WaitUntil(() => !GameStateManager.Instance.GetIsGamePaused);
            yield return new WaitForSeconds(1);
            a--;
        }

        if(GetComponentInParent<TowerInfoKeeper>().GetCurrentTowerCode != -1 && currentUnit.IsWaiting)
        {
            UpdateUnitCode();
        }
    }

    public void UpdateUnitCode()
    {
        CancelRespawnTimer();
        string animString = GetComponentInParent<TowerInfoKeeper>().CurrentTowerLevel.ToString();

        if(GetComponentInParent<TowerInfoKeeper>().GetCurrentTowerCode == 8)
        {
            animString = ConstStrings.ANIM2;
        }
        else if(GetComponentInParent<TowerInfoKeeper>().GetCurrentTowerCode == 9)
        {
            animString = ConstStrings.ANIM1;
        }

        currentUnit.IsWaiting = true;
        currentUnit.SetValues(spawnPos, AllUnitInfoKeeper.Instance.GetGuardInfo(GameTimer.Instance.GetCurrentMinute), 1);
        currentUnit.GetUnitAnimator().SetTrigger(animString);
        currentUnit.PlusDamageRange = GetComponentInParent<TowerInfoKeeper>().GetCurrentTowerInfo.BaseDamageRange * GetComponentInParent<TowerInfoKeeper>().GetExtraDamageFromDarkAura;
    }

    public void SetSpawnPos()
    {
        currentUnit.GetNavMeshAgent().Warp(spawnPos.position);
    }

    public void CancelRespawnTimer()
    {
        cts.Cancel();
    }

    void OnDestroy() 
    {
        GlobalUnitTargets.Instance.OnAnGuardDead -= GlobalUnitTargets_OnAnGuardDead;
        StopAllCoroutines();
        CancelRespawnTimer();
    }

}
