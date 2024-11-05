using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ActiveProjectileBaseClass : MonoBehaviour
{
    int damage;

    bool isEvolved;

    public bool IsEvolved
    {
        get => isEvolved;
        set => isEvolved = value;
    }

    public int GetDamage
    {
        get => damage;
    }

    public void SetBaseClassValues(int _damage, bool isEvolved)
    {
        damage = _damage;
        this.isEvolved = isEvolved;
    }

}
