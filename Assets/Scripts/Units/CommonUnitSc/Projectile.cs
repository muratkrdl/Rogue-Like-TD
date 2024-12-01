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

    public Transform GetTarget
    {
        get => target;
    }

    bool isAvailable = false;
    bool damageable = true;

    float currentDamage;

    public float GetCurrentDamage
    {
        get => currentDamage;
    }
    public DamageType GetDamageType
    {
        get => damageType;
    }

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
        if(trailRenderer != null)
        {
            ResetTrialRenderer();
        }
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
            Quaternion rotation = Quaternion.LookRotation(target.transform.position - transform.localPosition, transform.TransformDirection(Vector3.up));
            transform.SetPositionAndRotation(Vector2.MoveTowards(transform.localPosition, target.position, moveSpeed * Time.deltaTime), new Quaternion( 0 , 0 , rotation.z , rotation.w ));
            if(Mathf.Abs(Vector2.Distance(transform.localPosition, target.position)) <= .01f && damageable)
            {
                // Damage
                if(target.TryGetComponent<IDamageable>(out var component))
                {
                    component.SetHP((int) currentDamage, damageType);
                }
                damageable = false;
                VFX();
            }
        }

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
