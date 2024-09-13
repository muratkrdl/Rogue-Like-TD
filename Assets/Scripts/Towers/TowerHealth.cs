using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerHealth : MonoBehaviour, IDamageable
{
    int currenthealth;

    public int GetCurrentHealth
    {
        get
        {
            return currenthealth;
        }
    }

    public void SetTowerHealth(int amount)
    {
        currenthealth = amount;
    }

    public void TakeDamage(int amount)
    {
        currenthealth -= amount;
        if(InfoPanel.Instance.GetCurrentTowerInfoSO != GetComponent<TowerInfoKeeper>().GetCurrentTowerInfo) return;

        InfoPanel.Instance.OnClickedTowerInfo?.Invoke(this, new() { isMainTower = false, towerInfoSo1 = GetComponent<TowerInfoKeeper>().GetCurrentTowerInfo, tower = transform } );
    }

}
