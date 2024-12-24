using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrightShieldDamager : SkillProjectileDamagerBaseClass
{
    public void AnimEvent_SetCanTakeDamage()
    {
        GetComponentInParent<PlayerHealth>().SetCanTakeDamage(true);
    }

    protected override void EvolveFunc(Collider2D other)
    {
        GlobalUnitTargets.Instance.GetPlayerTarget().GetComponent<PlayerHealth>().SetHP(-2, DamageType.truedamage);
    }

    public void ExplosionSFX()
    {
        SoundManager.Instance.PlaySound2D(ConstStrings.BRIGHTSHIELDEXPLOSION);
    }

}
