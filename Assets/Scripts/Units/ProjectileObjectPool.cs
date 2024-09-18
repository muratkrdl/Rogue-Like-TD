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

    [Header("Projectiles")]
    [SerializeField] List<Projectile> man_With_Bow_Projectiles;
    [SerializeField] List<Projectile> wizard_Projectiles;
    [SerializeField] List<Projectile> others;

    [Header("Guards")]
    [SerializeField] List<GameObject> guard_Unit;

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
        GetProjectileList(e.code).Add(e.createdObj);
    }

    public Transform GetInstantiatedObjParent(int code)
    {
        return listsParent[code];
    }

    public List<Projectile> GetProjectileList(int code)
    {
        return code switch
        {
            0 => man_With_Bow_Projectiles,
            1 => wizard_Projectiles,
            2 => others,
            _ => throw new()
        };
    }

    public List<GameObject> GetGuardList(int code)
    {
        return code switch
        {
            0 => guard_Unit,
            _ => throw new()
        };
    }

    public Projectile GetProjectile(int code)
    {
        foreach (var item in GetProjectileList(code))
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
