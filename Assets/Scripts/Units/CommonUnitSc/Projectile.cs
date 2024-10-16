using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] GameObject spawnObj;

    [SerializeField] Animator vfxAnimator;

    Transform target;
    DamageType damageType;

    public Transform GetTarget
    {
        get => target;
    }

    bool isAvailable = false;
    bool damageable = true;

    float currentDamage;

    public bool GetIsAvailable
    {
        get => isAvailable;
    }

    public void SetValues(Transform target, Transform projectileOutPos, float Damage, DamageType damageType)
    {
        damageable = true;
        transform.position = projectileOutPos.position;
        this.target = target;
        this.damageType = damageType;
        currentDamage = Damage;
        isAvailable = false;
        GetComponent<SpriteRenderer>().enabled = true;
    }

    void Update() 
    {
        if(isAvailable) return;

        Quaternion rotation = Quaternion.LookRotation(target.transform.position - transform.localPosition ,transform.TransformDirection(Vector3.up));
        transform.SetPositionAndRotation(Vector2.MoveTowards(transform.localPosition, target.position, 1 * GlobalValues.Instance.GetDeltaTime), new Quaternion( 0 , 0 , rotation.z , rotation.w ));
    
        if(Mathf.Abs(Vector2.Distance(transform.localPosition, target.position)) <= .01f && damageable)
        {
            // Damage
            if(target.TryGetComponent<IDamageable>(out var component))
            {
                component.TakeDamage((int) currentDamage, damageType);
            }
            damageable = false;
            VFX();
        }
    }

    void VFX()
    {
        vfxAnimator.SetTrigger(ConstStrings.PROJECTILE_VFX_ANIMATE);
    }

    public void InstantiateObj() // özel yerlerde alan hasarı vermek için vs kullan
    {
        Instantiate(spawnObj, transform.position, Quaternion.identity);
    }

    public void SetTrueIsAvailable()
    {
        target = null;
        vfxAnimator.SetTrigger(ConstStrings.PROJECTILE_VFX_RESET);
        GetComponent<SpriteRenderer>().enabled = false;
        isAvailable = true;
    }

}
