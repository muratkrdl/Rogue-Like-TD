using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DaggerDamager : SkillProjectileDamagerBaseClass
{
    protected override void OnDamageFunc()
    {
        Damage = Damage/100*90;
    }
}
