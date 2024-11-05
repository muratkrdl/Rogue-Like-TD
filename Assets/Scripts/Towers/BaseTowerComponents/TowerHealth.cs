using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering.BuiltIn.ShaderGraph;
using UnityEngine;

public class TowerHealth : MonoBehaviour, IDamageable
{
    [SerializeField] FireAnimator fireAnimator;

    float maxHealth = 0;
    float currenthealth = 0;

    public float GetCurrentHealth
    {
        get => currenthealth;
    }

    public void SetTowerHealth(float amount)
    {
        currenthealth += amount - maxHealth;
        maxHealth = amount;
        fireAnimator.HealthChanged(currenthealth, maxHealth);
    }

    public void SetHP(float amount, DamageType damageType)
    {
        if(currenthealth <= 0) return;

        currenthealth -= amount;
        fireAnimator.HealthChanged(currenthealth, maxHealth);

        bool value;
        TowerInfoSo so;
        if(TryGetComponent<TowerInfoKeeper>(out var keeper))
        {
            so = keeper.GetCurrentTowerInfo;
            value = false;
        }
        else
        {
            so = GetComponent<MainTower>().GetTowerInfoSo;
            value = true;
        }

        if(currenthealth <= 0)
        {
            currenthealth = 0;

            if(value)
            {
                // gameOver 
            }
            else
            {
                GetComponent<PlaceTower>().ResetAllValues();
            }

            foreach (var item in GetComponentsInChildren<GuardTowerSkill>())
            {
                item.SetSpawnPos();
            }
        }
        
        if(InfoPanel.Instance.GetCurrentTowerInfoSO != so) return;

        InfoPanel.Instance.OnClickedTowerInfo?.Invoke(this, new() { isMainTower = value, towerInfoSo1 = so, tower = transform, underAttack = true } );
    }

    public void ResetHealthPoints()
    {
        maxHealth = 0;
        currenthealth = 0;
    }

}
