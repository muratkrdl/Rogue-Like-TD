using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerChange : MonoBehaviour
{
    [SerializeField] GameObject openTower;

    public GameObject GetOpenTower
    {
        get
        {
            return openTower;
        }
    }

    public void ChangeTower()
    {
        GetComponentInChildren<TowerUnitStateController>().ClearTokenSource();
        openTower.SetActive(true);
        gameObject.SetActive(false);
    }

    public void Reset()
    {
        if(!openTower.activeSelf) return;
        openTower.SetActive(false);
        openTower.GetComponent<Animator>().SetTrigger(ConstStrings.TOWER_RESET);
    }

}
