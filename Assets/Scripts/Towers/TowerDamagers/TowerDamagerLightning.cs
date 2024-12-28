using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks.Triggers;
using UnityEngine;

public class TowerDamagerLightning : DamageForEvolvedTowerProjectile
{
    [SerializeField] Animator animatorr;

    int counter;

    public int SetCounter
    {
        set => counter = value;
    }

    protected override void OnSpawn()
    {
        animatorr.SetTrigger(ConstStrings.ANIM);
        GetComponent<AudioSource>().Play();
    }

    protected override void OnTriggerFunc(Collider2D other)
    {
        counter++;
        
        if(counter <= (int)(GetDamage/5))
        {
            var obj = DamagerObjPool.Instance.GetDamagerObj(1);
            obj.GetComponent<TowerDamagerLightning>().SetCounter = 999;
            obj.SetValues(GetDamage, GetDamageType, other.transform.position);
        }
    }

}
