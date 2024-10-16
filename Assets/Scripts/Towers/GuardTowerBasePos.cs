using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardTowerBasePos : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag(TagManager.GUARD))
        {
            other.GetComponent<UnitValues>().IsWaiting = false;
        }    
    }
}
