using System.Collections.Generic;
using UnityEngine;

public class ActiveSkillProjectileObjectPool : MonoBehaviour
{
    public static ActiveSkillProjectileObjectPool Instance;

    [SerializeField] ActiveProjectile[] projectilePrefabs;

    [SerializeField] Transform[] listsParent;

    List<ActiveProjectile> bofList = new();
    List<ActiveProjectile> bloodRainList = new();
    List<ActiveProjectile> daggerList = new();
    List<ActiveProjectile> fireBallList = new();
    List<ActiveProjectile> spikeList = new();
    List<ActiveProjectile> tornadoList = new();
    List<ActiveProjectile> axeList = new();
    List<ActiveProjectile> fireballEvolved = new();
    List<ActiveProjectile> bofEvolved = new();
    List<ActiveProjectile> tornadoEvolved = new();

    void Awake() 
    {
        Instance = this;    
    }

    List<ActiveProjectile> GetProjectileList(int code)
    {
        return code switch
        {
            0 => bofList,
            1 => bloodRainList,
            2 => daggerList,
            3 => fireBallList,
            4 => spikeList,
            5 => tornadoList,
            6 => axeList,
            7 => fireballEvolved,
            8 => bofEvolved,
            9 => tornadoEvolved,
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
                return item;
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
