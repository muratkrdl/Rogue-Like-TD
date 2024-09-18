using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering.BuiltIn.ShaderGraph;
using UnityEngine;

public class TowerHealth : MonoBehaviour, IDamageable
{
    int currenthealth = 100;

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
        
        if(InfoPanel.Instance.GetCurrentTowerInfoSO != so) return;

        InfoPanel.Instance.OnClickedTowerInfo?.Invoke(this, new() { isMainTower = value, towerInfoSo1 = so, tower = transform } );
    }

}
