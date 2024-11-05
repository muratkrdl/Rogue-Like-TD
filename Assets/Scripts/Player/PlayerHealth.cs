using System;
using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour, IDamageable
{
    [SerializeField] Slider slider;

    [SerializeField] BrightShield brightShield;

    bool isDead = false;
    bool canTakeDamage = true;

    float currenthealth;

    public bool GetIsDead
    {
        get => isDead;
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
            _ = e.damage * (InventorySystem.Instance.GetSkillSO(8).Value / 100);
            SetHP(-e.damage, DamageType.truedamage);
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
            await UniTask.WaitUntil(() => !GameStateManager.Instance.GetIsGamePaused && currenthealth < slider.maxValue);
            await UniTask.Delay(TimeSpan.FromSeconds(InventorySystem.Instance.GetSkillSO(3).CooldDown - InventorySystem.Instance.GetSkillSO(3).CooldDown * InventorySystem.Instance.GetSkillSO(9).Value / 100));
            await UniTask.WaitUntil(() => !GameStateManager.Instance.GetIsGamePaused && currenthealth < slider.maxValue);
            Debug.Log("Regen");
            SetHP(-InventorySystem.Instance.GetSkillSO(3).Value, DamageType.truedamage);
        }
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
            Invoke(nameof(PlayerDead), 1);
        }
        else if(currenthealth >= slider.maxValue)
        {
            currenthealth = (int)slider.maxValue;
            slider.value = currenthealth;
        }
    }

    void UpdateMaxHealth()
    {
        slider.maxValue += InventorySystem.Instance.GetSkillSO(2).Value;
        currenthealth += InventorySystem.Instance.GetSkillSO(2).Value;
        slider.value = currenthealth;
    }

    void PlayerDead()
    {
        MainTowerManager.Instance.OnInteractWithMainTower?.Invoke(this, EventArgs.Empty);
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
    }

}
