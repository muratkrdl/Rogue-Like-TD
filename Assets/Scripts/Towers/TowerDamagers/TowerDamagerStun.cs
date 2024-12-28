using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerDamagerStun : DamageForEvolvedTowerProjectile
{
    protected override void OnTriggerFunc(Collider2D collider2D)
    {
        GetComponent<AudioSource>().Play();
        collider2D.GetComponent<UnitValues>().StunSlowUnit(0, .5f).Forget();
    }

}
