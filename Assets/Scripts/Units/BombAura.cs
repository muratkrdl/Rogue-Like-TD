using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombAura : MonoBehaviour
{
    [SerializeField] DamageType damageType;

    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.TryGetComponent<IDamageable>(out var component) && !other.CompareTag(TagManager.ENEMY))
        {
            component.TakeDamage(50, damageType);
        }
    }
}
