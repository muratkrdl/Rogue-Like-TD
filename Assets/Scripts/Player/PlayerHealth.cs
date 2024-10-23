using System;
using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour, IDamageable
{
    [SerializeField] Slider slider;

    bool isDead = false;

    int currenthealth;

    public bool GetIsDead
    {
        get => isDead;
    }
    public int GetCurrentHealth
    {
        get => currenthealth;
    }

    void Start() 
    {
        slider.maxValue = 100;
        currenthealth = (int)slider.maxValue;
        slider.value = currenthealth;

        InventorySystem.Instance.OnPasifeUpdate += InventorySystem_OnPasifeUpdate;
        InventorySystem.Instance.OnDamageWithActiveSkills += InventorySystem_OnDamageWithActiveSkills;
        HelathRegen().Forget();
    }

    void InventorySystem_OnDamageWithActiveSkills(object sender, InventorySystem.OnDamageWithActiveSkillsEventArgs e)
    {
        if(currenthealth < slider.maxValue)
        {
            TakeDamage(-e.damage, DamageType.truedamage);
            if(currenthealth >= slider.maxValue)
                currenthealth = (int)slider.maxValue;
            
            slider.value = currenthealth;
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
            if(GameStateManager.Instance.GetIsGamePaused || currenthealth >= slider.maxValue) return;
            await UniTask.Delay(TimeSpan.FromSeconds(InventorySystem.Instance.GetSkillSO(3).CooldDown - InventorySystem.Instance.GetSkillSO(3).CooldDown * InventorySystem.Instance.GetSkillSO(9).Value / 100));
            TakeDamage(-InventorySystem.Instance.GetSkillSO(3).Value, DamageType.truedamage);
        }
    }

    public void TakeDamage(int amount, DamageType damageType)
    {
        if(isDead) return;

        amount = SetNewDamage(amount, damageType);

        currenthealth -= amount;
        
        slider.value = currenthealth;

        if(currenthealth <= 0)
        {
            currenthealth = 0;
            isDead = true;
            GetComponent<Animator>().SetTrigger(ConstStrings.UNIT_ANIMATOR_DEATH);
            Invoke(nameof(PlayerDead), 1);
        }
    }

    void UpdateMaxHealth()
    {
        slider.maxValue = 100 + InventorySystem.Instance.GetSkillSO(2).Value;
        currenthealth += (int)slider.maxValue - InventorySystem.Instance.GetSkillSO(2).Value;
        slider.value = currenthealth;
    }

    void PlayerDead()
    {
        MainTowerManager.Instance.OnInteractWithMainTower?.Invoke(this, EventArgs.Empty);
    }

    int SetNewDamage(int amount, DamageType damageType)
    {
        int returnInteger = amount;

        if(damageType == DamageType.physical)
        {
            returnInteger *= (100-InventorySystem.Instance.GetSkillSO(0).Value*10) / 100;
        }
        else if(damageType == DamageType.magic)
        {
            returnInteger *= (100-InventorySystem.Instance.GetSkillSO(1).Value*11) / 100;
        }

        return returnInteger;
    }

    void OnDestroy() 
    {
        InventorySystem.Instance.OnPasifeUpdate -= InventorySystem_OnPasifeUpdate;
        InventorySystem.Instance.OnDamageWithActiveSkills -= InventorySystem_OnDamageWithActiveSkills;
    }

}
