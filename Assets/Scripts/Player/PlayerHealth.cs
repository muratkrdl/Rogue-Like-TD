using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour, IDamageable
{
    [SerializeField] Slider slider;

    int currenthealth;

    public int GetCurrentHealth
    {
        get
        {
            return currenthealth;
        }
    }

    void Start() 
    {
        slider.maxValue = 100;
        currenthealth = (int)slider.maxValue;
        slider.value = currenthealth;
    }

    public void TakeDamage(int amount)
    {
        currenthealth -= amount;
        
        slider.value = currenthealth;
    }

}
