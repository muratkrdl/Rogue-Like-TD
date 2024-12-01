using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedAura : MonoBehaviour
{
    [SerializeField] float increaseSpeed;

    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag(TagManager.ENEMY))
        {
            other.GetComponent<UnitValues>().SetUnitSpeed(other.GetComponent<UnitValues>().GetInitialMoveSpeed * increaseSpeed);
        }
    }

    void OnTriggerStay2D(Collider2D other) 
    {
        if(other.CompareTag(TagManager.ENEMY) && !other.GetComponent<UnitValues>().IsSpeedChanged) // stunned return
        {
            other.GetComponent<UnitValues>().SetUnitSpeed(other.GetComponent<UnitValues>().GetInitialMoveSpeed * increaseSpeed);
        }
    }

    void OnTriggerExit2D(Collider2D other) 
    {
        if(other.CompareTag(TagManager.ENEMY))
        {
            other.GetComponent<UnitValues>().SetUnitSpeedBaseValue();
        }
    }
}
