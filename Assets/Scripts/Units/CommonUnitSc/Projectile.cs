using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] TrailRenderer trailRenderer;

    [SerializeField] Animator vfxAnimator;

    [SerializeField] float moveSpeed = 1;

    Transform target;
    DamageType damageType;

    Vector3 direction;

    bool isAvailable = false;
    bool damageable = true;
    bool followable = false;

    float damage;

    public Transform GetTarget
    {
        get => target;
    }
    public float GetDamage
    {
        get => damage;
    }
    public DamageType GetDamageType
    {
        get => damageType;
    }

    public bool GetIsAvailable
    {
        get => isAvailable;
    }

    public void SetValues(Transform target, Transform projectileOutPos, float damage, DamageType damageType, bool followable)
    {
        vfxAnimator.SetTrigger(ConstStrings.RESET);

        isAvailable = false;
        damageable = true;

        this.damageType = damageType;
        this.followable = followable;
        this.target = target;
        this.damage = damage;

        transform.position = projectileOutPos.position;
        direction = target.position - transform.position;
        direction.Normalize();

        float rot_z = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rot_z);

        GetComponent<SpriteRenderer>().enabled = true;

        if(trailRenderer != null)
        {
            ResetTrialRenderer();
        }

        Invoke(nameof(DeactiveProjectile), 15);
    }

    void Update() 
    {
        if(isAvailable || GameStateManager.Instance.GetIsGamePaused || !damageable || target == null) return;

        if((target.TryGetComponent<UnitValues>(out var component1) && component1.IsDead) || target == null)
        {
            SetTrueIsAvailable();
        }

        if(target != null)
        {
            if(followable)
            {
                Quaternion rotation = Quaternion.LookRotation(target.transform.position - transform.localPosition, transform.TransformDirection(Vector3.up));
                transform.SetPositionAndRotation(Vector2.MoveTowards(transform.localPosition, target.position, moveSpeed * Time.deltaTime), new Quaternion( 0 , 0 , rotation.z , rotation.w ));
            }
            else
            {
                transform.position = Vector2.MoveTowards(transform.localPosition, transform.position + direction, moveSpeed * Time.deltaTime);
            }

            if(Mathf.Abs(Vector2.Distance(transform.localPosition, target.position)) <= .25f && damageable)
            {
                // Damage
                damageable = false;
                if(target.TryGetComponent<IDamageable>(out var component))
                {
                    component.SetHP(damage, damageType);
                }
                VFX();
            }
        }
    }

    void DeactiveProjectile()
    {
        if(!isAvailable) return;
        VFX();
    }

    void VFX()
    {
        vfxAnimator.SetTrigger(ConstStrings.PROJECTILE_VFX_ANIMATE);
    }

    public void SetTrueIsAvailable()
    {
        target = null;
        vfxAnimator.SetTrigger(ConstStrings.RESET);
        GetComponent<SpriteRenderer>().enabled = false;
        isAvailable = true;
    }

    public void ResetTrialRenderer()
    {
        trailRenderer.Clear();
    }

}
