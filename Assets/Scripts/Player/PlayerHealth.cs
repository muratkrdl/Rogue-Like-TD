using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour, IDamageable
{
    [SerializeField] Slider slider;

    [SerializeField] BrightShield brightShield;

    [SerializeField] int respawnTimer;

    CancellationTokenSource cts = new();

    bool isDead = false;
    bool canTakeDamage = true;

    float currenthealth;

    public bool IsDead
    {
        get => isDead;
        set => isDead = value;
    }
    public float GetCurrentHealth
    {
        get => currenthealth;
    }

    void Start() 
    {
        slider.maxValue = 100;
        currenthealth = (int)slider.maxValue;
        slider.value = currenthealth;

        InventorySystem.Instance.OnSkillUpdate += InventorySystem_OnPasifeUpdate;
        InventorySystem.Instance.OnDamageWithActiveSkills += InventorySystem_OnDamageWithActiveSkills;
        HelathRegen().Forget();
    }

    void InventorySystem_OnDamageWithActiveSkills(object sender, InventorySystem.OnDamageWithActiveSkillsEventArgs e)
    {
        if(InventorySystem.Instance.GetSkillSO(8).Value == 0) return;

        if(currenthealth < slider.maxValue)
        {
            float takenDamage = e.damage * ((float)InventorySystem.Instance.GetSkillSO(8).Value / 100);
            SetHP(-takenDamage, DamageType.truedamage);
        }
    }

    void InventorySystem_OnPasifeUpdate(object sender, InventorySystem.OnSkillUpdateEventArgs e)
    {
        if(e.Code == 2)
        {
            UpdateMaxHealth();
        }
    }

    async UniTaskVoid HelathRegen()
    {
        await UniTask.WaitUntil(() => InventorySystem.Instance.GetSkillSO(3).Value != 0);
        while(true)
        {
            await UniTask.WaitUntil(() => GlobalUnitTargets.Instance.CanPlayerUseSkill() && currenthealth < slider.maxValue, 
            cancellationToken: cts.Token);
            await UniTask.Delay(TimeSpan.FromSeconds(InventorySystem.Instance.GetSkillSO(3).CooldDown - 
            InventorySystem.Instance.GetSkillSO(3).CooldDown * InventorySystem.Instance.GetSkillSO(9).Value / 100), cancellationToken: cts.Token);
            await UniTask.WaitUntil(() => GlobalUnitTargets.Instance.CanPlayerUseSkill() && currenthealth < slider.maxValue, cancellationToken: cts.Token);
            GainHP(-InventorySystem.Instance.GetSkillSO(3).Value + PermanentSkillSystem.Instance.GetPermanentSkillSO(5).Value);
        }
    }

    public void GainHP(float amount)
    {
        currenthealth += amount;
        if(currenthealth >= slider.maxValue)
            currenthealth = slider.maxValue;
        slider.value = currenthealth;
    }

    public void SetHP(float amount, DamageType damageType)
    {
        brightShield.OnTakeDamage?.Invoke(this, new() { damage = amount } );

        if(isDead || !canTakeDamage) return;

        amount = SetNewDamage(amount, damageType);

        currenthealth -= amount;
        
        slider.value = currenthealth;

        if(currenthealth <= 0)
        {
            currenthealth = 0;
            isDead = true;
            GetComponent<Animator>().SetTrigger(ConstStrings.UNIT_ANIMATOR_DEATH);
            GetComponent<GetInputs>().ResetMoveInput();
            Invoke(nameof(PlayerDead), 1);
        }
        else if(currenthealth >= slider.maxValue)
        {
            currenthealth = slider.maxValue;
            slider.value = currenthealth;
        }
    }

    public void UpdateMaxHealth()
    {
        slider.maxValue = 100 + InventorySystem.Instance.GetSkillSO(2).Value + PermanentSkillSystem.Instance.GetPermanentSkillSO(4).Value; // 100 = baseHP
        currenthealth += InventorySystem.Instance.GetSkillSO(2).Value + PermanentSkillSystem.Instance.GetPermanentSkillSO(4).Value;
        slider.value = currenthealth;
    }

    void PlayerDead()
    {
        if(GameOverMenu.Instance.IsGameOver) return;
        MainTowerManager.Instance.OnInteractWithMainTower?.Invoke(this, new() { state = MainTowerInOutStates.inTower } );
        RespawnPlayer(respawnTimer).Forget();
    }

    public async UniTaskVoid RespawnPlayer(int respawnTimer)
    {
        PlayerDeadPanel.Instance.SetPanel(true);
        int currentTimer = respawnTimer - PermanentSkillSystem.Instance.GetPermanentSkillSO(8).Value;
        PlayerDeadPanel.Instance.OnDeadTimerUpdate?.Invoke(this, new() { amount = currentTimer } );
        while(true)
        {
            await UniTask.WaitUntil(() => !GameStateManager.Instance.GetIsGamePaused, cancellationToken: cts.Token);
            await UniTask.Delay(TimeSpan.FromSeconds(1), cancellationToken: cts.Token);
            currentTimer--;
            PlayerDeadPanel.Instance.OnDeadTimerUpdate?.Invoke(this, new() { amount = currentTimer } );
            if(currentTimer <= 0)
            {
                RespawnPlayerResetValues();
                PlayerDeadPanel.Instance.SetPanel(false);
                break;
            }
        }
    }

    public void RespawnPlayerResetValues()
    {
        currenthealth = slider.maxValue;
        slider.value = currenthealth;
        isDead = false;
        transform.position = GlobalUnitTargets.Instance.GetPlayerRespawnPos;
    }

    float SetNewDamage(float amount, DamageType damageType)
    {
        float returnAmount = amount;

        if(damageType == DamageType.physical)
        {
            returnAmount *= (float)(100-InventorySystem.Instance.GetSkillSO(0).Value) / 100;
        }
        else if(damageType == DamageType.magic)
        {
            returnAmount *= (float)(100-InventorySystem.Instance.GetSkillSO(1).Value) / 100;
        }

        return returnAmount;
    }

    public void SetCanTakeDamage(bool value)
    {
        canTakeDamage = value;
    }

    void OnDestroy() 
    {
        InventorySystem.Instance.OnSkillUpdate -= InventorySystem_OnPasifeUpdate;
        InventorySystem.Instance.OnDamageWithActiveSkills -= InventorySystem_OnDamageWithActiveSkills;
        cts.Cancel();
    }

}
