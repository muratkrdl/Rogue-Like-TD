using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TornadoDamager : SkillProjectileDamagerBaseClass
{
    protected override void EvolveFunc(Collider2D other)
    {
        other.GetComponent<UnitHealth>().DamageWithPoison(InventorySystem.Instance.GetSkillSO(GetSkillCode).Value / 10, (int)InventorySystem.Instance.GetSkillSO(GetSkillCode).Size);
    }

    protected override void OnDamageFunc()
    {
        Damage = Damage/100*90;
    }
}
