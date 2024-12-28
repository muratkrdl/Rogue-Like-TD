using UnityEngine;

public class SpikeDamager : SkillProjectileDamagerBaseClass
{
    protected override void EvolveFunc(Collider2D other)
    {
        other.GetComponent<UnitValues>().StunSlowUnit(.5f, 1f).Forget();
    }
    
}
