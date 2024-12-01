using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class TowerInfoKeeper : MonoBehaviour
{
    [SerializeField] ParticleSystem hasExtraDamageFromDarkAuraVFX;
    [SerializeField] ParticleSystem hasExtraAttackSpeedFromBloodRainVFX;

    [SerializeField] EvolvedBuildAnim evolvedBuildAnim;

    [SerializeField] TowerHealth towerHealth;

    [SerializeField] Image rangeCircle;

    TowerInfoSo currentTowerInfo;

    CancellationTokenSource ctsExtraDamage = new();
    CancellationTokenSource ctsExtraAttackSpeed = new();

    int currentTowerLevel = 1;
    int currentTowerCode = -1;

    int clickedTowerCode;

    float extraDamageFromDarkAura;
    float extraAttackSpeedFromBloodRain;

    public int ClickedTowerCode
    {
        get => clickedTowerCode;
        set => clickedTowerCode = value;
    }
    public int CurrentTowerLevel
    {
        get => currentTowerLevel;
        set => currentTowerLevel = value;
    }
    public float GetExtraDamageFromDarkAura
    {
        get => extraDamageFromDarkAura;
    }
    public float GetExtraAttackSpeedFromBloodRain
    {
        get => extraAttackSpeedFromBloodRain;
    }

    public TowerInfoSo GetCurrentTowerInfo
    {
        get => currentTowerInfo;
    }

    public int GetCurrentTowerCode
    {
        get => currentTowerCode;
    }
    
    public void SetCurrentTowerInfo(int i, int level)
    {
        currentTowerInfo = AllTowerInfos.Instance.GetTowerInfoSo(i, level);
        currentTowerCode = i;
        rangeCircle.transform.localScale = new(currentTowerInfo.Range, currentTowerInfo.Range);
        GetComponentInChildren<TowerEnemyKeeper>().SetNewCollider(currentTowerInfo.Range);
        towerHealth.SetTowerHealth(GetCurrentTowerInfo.maxHealth + PermanentSkillSystem.Instance.GetPermanentSkillSO(11).Value);
    }

    public void ResetAllValues()
    {
        currentTowerInfo = null;
        currentTowerLevel = 1;
        currentTowerCode = -1;
        clickedTowerCode = 0;
        extraDamageFromDarkAura = 1;
        rangeCircle.transform.localScale = Vector2.zero;
        towerHealth.ResetHealthPoints();
    }

    public EvolvedBuildAnim GetEvolvedBuildAnim()
    {
        return evolvedBuildAnim;
    }

    public void SetExtraDamageFromDarkAura(float value)
    {
        if(currentTowerCode == -1) return;
        ctsExtraDamage.Cancel();
        ctsExtraDamage = new();
        SetExtraDamageFromDarkAuraUnitask(value, value * 3).Forget();
    }

    async UniTaskVoid SetExtraDamageFromDarkAuraUnitask(float value, float Delay)
    {
        extraDamageFromDarkAura = value;
        hasExtraDamageFromDarkAuraVFX.Play();
        await UniTask.Delay(System.TimeSpan.FromSeconds(Delay), cancellationToken: ctsExtraDamage.Token);
        extraDamageFromDarkAura = 1;
        hasExtraDamageFromDarkAuraVFX.Stop();
    }

    public void SetExtraAttackSpeedFromBloodRain(float value)
    {
        if(currentTowerCode == -1) return;
        ctsExtraAttackSpeed.Cancel();
        ctsExtraAttackSpeed = new();
        SetExtraAttackSpeedFromBloodRainUnitask(value, value * 20).Forget();
    }

    async UniTaskVoid SetExtraAttackSpeedFromBloodRainUnitask(float value, float Delay)
    {
        extraAttackSpeedFromBloodRain = value;
        hasExtraAttackSpeedFromBloodRainVFX.Play();
        await UniTask.Delay(System.TimeSpan.FromSeconds(Delay), cancellationToken: ctsExtraAttackSpeed.Token);
        extraAttackSpeedFromBloodRain = 0;
        hasExtraAttackSpeedFromBloodRainVFX.Stop();
    }

}
