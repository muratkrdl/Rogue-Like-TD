using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForEvolvedTowerWeapon : MonoBehaviour
{
    [SerializeField] TowerUnitValues towerUnitValues;

    Vector2 offset;

    void Update()
    {
        offset = towerUnitValues.GetTowerUnitSetTarget().GetCurrentTarget.position - transform.position;
        offset.Normalize();
        float rot_z = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);
    }
}
