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
        openTower.SetActive(true);
        gameObject.SetActive(false);
    }

}
