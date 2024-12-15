using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballDamager : SkillProjectileDamagerBaseClass
{
    protected override void OnDamageFunc()
    {
        Damage = Damage/100*90;
    }
}
