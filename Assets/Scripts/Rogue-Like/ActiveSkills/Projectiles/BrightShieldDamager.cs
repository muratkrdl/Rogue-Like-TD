using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrightShieldDamager : SkillProjectileDamagerBaseClass
{
    public void AnimEvent_SetCanTakeDamage()
    {
        GetComponentInParent<PlayerHealth>().SetCanTakeDamage(true);
    }
}
