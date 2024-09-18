using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainTower : MonoBehaviour
{
    [SerializeField] TowerInfoSo towerInfoSo;

    public TowerInfoSo GetTowerInfoSo
    {
        get
        {
            return towerInfoSo;
        }
    }

    void OnMouseDown()
    {
        InfoPanel.Instance.OnClickedTowerInfo?.Invoke(this, new() { towerInfoSo1 = towerInfoSo, isMainTower = true, tower = transform } );
    }

}
