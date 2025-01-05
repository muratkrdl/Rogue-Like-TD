using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Unity.VisualScripting;
using UnityEngine;

public class TowerChange : MonoBehaviour
{
    [SerializeField] GameObject openTower;

    public GameObject GetOpenTower
    {
        get => openTower;
    }

    public void ChangeTower()
    {
        if(GetComponentInChildren<Animator>().TryGetComponent<TowerUnitStateController>(out var component))
            component.ClearTokenSource();
        
        openTower.SetActive(true);
        if(openTower.TryGetComponent<GuardTowerSkill>(out var component1))
        {
            component1.UpdateUnitCode();
        }
        gameObject.SetActive(false);
    }

    public void Reset()
    {
        if(!openTower.activeInHierarchy) return;
        
        openTower.GetComponent<Animator>().SetTrigger(ConstStrings.RESET);
        openTower.SetActive(false);
    }

}
