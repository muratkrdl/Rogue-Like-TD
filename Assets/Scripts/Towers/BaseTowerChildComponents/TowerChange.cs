using System.Collections;
using System.Collections.Generic;
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
        gameObject.SetActive(false);
    }

    public void Reset()
    {
        if(!openTower.activeSelf) return;
        
        openTower.SetActive(false);
        openTower.GetComponent<Animator>().SetTrigger(ConstStrings.RESET);
    }

}
