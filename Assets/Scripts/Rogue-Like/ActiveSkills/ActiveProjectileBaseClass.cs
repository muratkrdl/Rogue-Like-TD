using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ActiveProjectileBaseClass : MonoBehaviour
{
    int damage;

    public int GetDamage
    {
        get => damage;
    }

    public void SetBaseClassValues(int _damage)
    {
        damage = _damage;
    }

}
