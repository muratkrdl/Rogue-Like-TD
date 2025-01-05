using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering.BuiltIn.ShaderGraph;
using UnityEngine;

public class TowerHealth : MonoBehaviour, IDamageable
{
    [SerializeField] FireAnimator fireAnimator;

    int maxHealth = 0;
    int currenthealth = 0;

    public float GetCurrentHealth
    {
        get => currenthealth;
    }

    public void SetTowerHealth(int amount)
    {
        currenthealth += amount - maxHealth;
        maxHealth = amount;
        fireAnimator.HealthChanged(currenthealth, maxHealth);
    }

    public void SetHP(float amount, DamageType damageType)
    {
        if(currenthealth <= 0) return;

        currenthealth -= (int)amount;
        if(currenthealth > maxHealth)
            currenthealth = maxHealth;

        float returnHealth = currenthealth;

        bool isMainTower;
        TowerInfoSo so;
        if(TryGetComponent<TowerInfoKeeper>(out var keeper))
        {
            so = keeper.GetCurrentTowerInfo;
            isMainTower = false;
            returnHealth--;
        }
        else
        {
            so = GetComponent<MainTower>().GetTowerInfoSo;
            isMainTower = true;
            returnHealth++;
        }

        fireAnimator.HealthChanged(returnHealth, maxHealth);

        if(currenthealth <= 0)
        {
            currenthealth = 0;

            if(isMainTower)
            {
                // gameOver 
                GlobalUnitTargets.Instance.GetPlayerTarget().GetComponent<PlayerHealth>().IsDead = true;
                MainTowerManager.Instance.OnInteractWithMainTower?.Invoke(this, new() { state = MainTowerInOutStates.inTower } );
                GameOverMenu.Instance.GameOver(false);
                Invoke(nameof(InvokeExploAnim), 1);
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

        InfoPanel.Instance.OnClickedTowerInfo?.Invoke(this, new() { isMainTower = isMainTower, towerInfoSo1 = so, tower = transform, underAttack = true } );
    }

    public void SetFullTowerHP()
    {
        SetHP(-999, DamageType.truedamage);
        transform.GetChild(3).GetComponent<ParticleSystem>().Play();
    }

    void InvokeExploAnim()
    {
        transform.GetChild(2).GetComponent<Animator>().SetTrigger(ConstStrings.ANIM);
    }

    public void ResetHealthPoints()
    {
        maxHealth = 0;
        currenthealth = 0;
    }

}
