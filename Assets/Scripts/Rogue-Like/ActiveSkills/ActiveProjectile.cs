using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveProjectile : ActiveProjectileBaseClass
{
    [SerializeField] DamageType damageType;
    [SerializeField] float extraRot;

    Vector2 lookPos;

    bool isWaiting = false;

    public bool IsWaiting
    {
        get => isWaiting;
        set => isWaiting = value;
    }

    public Vector2 GetLookPos
    {
        get => lookPos;
    }

    public void SetLookPos(Vector2 a, Vector3 pos)
    {
        GetComponent<SpriteRenderer>().enabled = true;
        isWaiting = false;
        transform.position = pos;

        lookPos = a;

        Vector2 offset = lookPos - Vector2.zero;
        offset.Normalize();
        float rot_z = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rot_z + extraRot);

        Invoke(nameof(AnimEvent_SetTrueIsWaiting), 5);
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag(TagManager.ENEMY) && !isWaiting)
        {
            other.GetComponent<UnitHealth>().TakeDamageFromPlayer(GetDamage, damageType);
        }
    }

    public void AnimEvent_SetTrueIsWaiting()
    {
        GetComponent<SpriteRenderer>().enabled = false;
        isWaiting = true;
    }

}
