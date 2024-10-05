using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] GameObject spawnObj;

    [SerializeField] Animator vfxAnimator;

    Transform target;

    bool isAvailable = false;
    bool damageable = true;

    float currentDamage;

    public bool GetIsAvailable
    {
        get
        {
            return isAvailable;
        }
    }

    public void SetValues(Transform target, Transform projectileOutPos, float Damage)
    {
        damageable = true;
        transform.position = projectileOutPos.position;
        this.target = target;
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
                component.TakeDamage((int) currentDamage);
            }
            damageable = false;
            VFX();
        }
    }

    void VFX()
    {
        vfxAnimator.SetTrigger(ConstStrings.PROJECTILE_VFX_ANIMATE);
    }

    public void InstantiateObj()
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
