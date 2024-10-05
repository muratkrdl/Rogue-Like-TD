using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerProjectileOutPos : MonoBehaviour
{
    [SerializeField] TowerUnitValues towerUnitValues;

    void Update()
    {
        transform.localPosition = new Vector2(towerUnitValues.GetTowerUnitSetTarget().GetLastDir.x / 3f, towerUnitValues.GetTowerUnitSetTarget().GetLastDir.y / 5);
    }
}
