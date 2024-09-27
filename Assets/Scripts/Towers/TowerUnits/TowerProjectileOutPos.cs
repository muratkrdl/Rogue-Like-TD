using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerProjectileOutPos : MonoBehaviour
{
    [SerializeField] TowerUnitValues towerUnitValues;

    Vector2 value;

    void Update()
    {
        value = new Vector2(Mathf.Sign(towerUnitValues.GetTowerUnitSetTarget().GetLastDir.x), Mathf.Sign(towerUnitValues.GetTowerUnitSetTarget().GetLastDir.y));
        
        transform.localPosition = new Vector2(-value.x / 3.07f, value.y / 7.40f);
    }
}
