using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveSkillProjectileObjectPool : MonoBehaviour
{
    public static ActiveSkillProjectileObjectPool Instance;

    [SerializeField] ActiveProjectile[] projectilePrefabs;

    [SerializeField] Transform[] listsParent;

    List<ActiveProjectile> bofList = new();
    List<ActiveProjectile> daggerList = new();

    void Awake() 
    {
        Instance = this;    
    }

    List<ActiveProjectile> GetProjectileList(int code)
    {
        return code switch
        {
            0 => bofList,
            1 => daggerList,
            _ => throw new()
        };
    }

    Transform GetInstantiatedObjParent(int code)
    {
        return listsParent[code];
    }

    public ActiveProjectile GetProjectile(int code)
    {
        foreach (var item in GetProjectileList(code))
        {
            if(item.IsWaiting)
            {
                return item;
            }
            else
            {
                continue;
            }
        }

        ActiveProjectile projectile = Instantiate(GetProjectilePrefab(code), transform.position, Quaternion.identity, 
        GetInstantiatedObjParent(code)).GetComponent<ActiveProjectile>();

        GetProjectileList(code).Add(projectile);

        return projectile;
    }

    ActiveProjectile GetProjectilePrefab(int code)
    {
        return projectilePrefabs[code];
    }

}
