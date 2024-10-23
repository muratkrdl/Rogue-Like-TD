using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkAuraDamager : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag(TagManager.ENEMY))
        {
            other.GetComponent<UnitHealth>().TakeDamageFromPlayer(InventorySystem.Instance.GetSkillSO(15).Value, DamageType.magic);
        }
    }
    
}
