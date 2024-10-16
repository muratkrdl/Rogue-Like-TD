using System;
using System.Collections;
using System.Collections.Generic;
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

    void PlayerDead()
    {
        MainTowerManager.Instance.OnInteractWithMainTower?.Invoke(this, EventArgs.Empty);
    }

    int SetNewDamage(int amount, DamageType damageType)
    {
        int returnInteger = amount;

        if(damageType == DamageType.physical)
        {
            // returnInteger *= (100-unitValues.UnitSO.Armor*20) / 100;
        }
        else if(damageType == DamageType.magic)
        {
            // returnInteger *= (100-unitValues.UnitSO.MagicResistance*20) / 100;
        }

        return returnInteger;
    }

}
