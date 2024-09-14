using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileObjectPool : MonoBehaviour
{
    public static ProjectileObjectPool Instance;

    public EventHandler<OnCreatedProjectileObjEventArgs> OnCreatedProjectileObj;
    public class OnCreatedProjectileObjEventArgs : EventArgs
    {
        public int code;
        public Projectile createdObj;
    }

    [SerializeField] Transform[] listsParent;

    [SerializeField] List<Projectile> man_With_Bow_Projectiles;
    [SerializeField] List<Projectile> wizard_Projectiles;
    [SerializeField] List<Projectile> others;

    void Awake() 
    {
        Instance = this;
    }

    void Start() 
    {
        OnCreatedProjectileObj += ProjectileObjectPool_OnCreatedProjectileObj;
    }

    void OnDestroy() 
    {
        OnCreatedProjectileObj -= ProjectileObjectPool_OnCreatedProjectileObj;
    }

    void ProjectileObjectPool_OnCreatedProjectileObj(object sender, OnCreatedProjectileObjEventArgs e)
    {
        GetList(e.code).Add(e.createdObj);
    }

    public Transform GetInstantiatedObjParent(int code)
    {
        return listsParent[code];
    }

    public List<Projectile> GetList(int code)
    {
        return code switch
        {
            0 => man_With_Bow_Projectiles,
            1 => wizard_Projectiles,
            2 => others,
            _ => throw new()
        };
    }

    public Projectile GetProjectile(int code)
    {
        foreach (var item in GetList(code))
        {
            if(item.GetIsAvailable)
            {
                return item;
            }
            else
            {
                continue;
            }
        }

        return null;
    }
}
