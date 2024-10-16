using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileObjectPool : MonoBehaviour
{
    public static ProjectileObjectPool Instance;

    [SerializeField] Projectile[] projectilesPrefabs;

    [SerializeField] Transform[] listsParent;

    #region ProjectilesLists
    List<Projectile> archer_Projectiles = new();
    List<Projectile> mage_1_Projectiles = new();
    List<Projectile> mage_2_Projectiles = new();
    List<Projectile> mage_3_Projectiles = new();
    List<Projectile> catapult_1_Projectiles = new();
    List<Projectile> catapult_2_Projectiles = new();
    List<Projectile> catapult_3_Projectiles = new();
    List<Projectile> Archer_Evolved_1_level_1_Projectile = new();
    List<Projectile> Archer_Evolved_1_level_2_Projectile = new();
    List<Projectile> Archer_Evolved_1_level_3_Projectile = new();
    List<Projectile> Archer_Evolved_2_level_1_Projectile = new();
    List<Projectile> Archer_Evolved_2_level_2_Projectile = new();
    List<Projectile> Archer_Evolved_2_level_3_Projectile = new();
    List<Projectile> Catapult_Evolved_1_level_1_Projectile = new();
    List<Projectile> Catapult_Evolved_1_level_2_Projectile = new();
    List<Projectile> Catapult_Evolved_1_level_3_Projectile = new();
    List<Projectile> Catapult_Evolved_2_level_1_Projectile = new();
    List<Projectile> Catapult_Evolved_2_level_2_Projectile = new();
    List<Projectile> Catapult_Evolved_2_level_3_Projectile = new();
    List<Projectile> Mage_Evolved_1_level_1_Projectile = new();
    List<Projectile> Mage_Evolved_1_level_2_Projectile = new();
    List<Projectile> Mage_Evolved_1_level_3_Projectile = new();
    List<Projectile> Mage_Evolved_2_level_1_Projectile = new();
    List<Projectile> Mage_Evolved_2_level_2_Projectile = new();
    List<Projectile> Mage_Evolved_2_level_3_Projectile = new();
    List<Projectile> man_With_Bow_Projectiles = new();
    List<Projectile> witch_Projectile = new();
    List<Projectile> others = new();
    #endregion

    void Awake() 
    {
        Instance = this;
    }

    public List<Projectile> GetProjectileList(int code)
    {
        return code switch
        {
            0 => archer_Projectiles,
            1 => mage_1_Projectiles,
            2 => mage_2_Projectiles,
            3 => mage_3_Projectiles,
            4 => catapult_1_Projectiles,
            5 => catapult_2_Projectiles,
            6 => catapult_3_Projectiles,
            7 => Archer_Evolved_1_level_1_Projectile,
            8 => Archer_Evolved_1_level_2_Projectile,
            9 => Archer_Evolved_1_level_3_Projectile,
            10 => Archer_Evolved_2_level_1_Projectile,
            11 => Archer_Evolved_2_level_2_Projectile,
            12 => Archer_Evolved_2_level_3_Projectile,  
            13 => Catapult_Evolved_1_level_1_Projectile,
            14 => Catapult_Evolved_1_level_2_Projectile,
            15 => Catapult_Evolved_1_level_3_Projectile,
            16 => Catapult_Evolved_2_level_1_Projectile,
            17 => Catapult_Evolved_2_level_2_Projectile,
            18 => Catapult_Evolved_2_level_3_Projectile,
            19 => Mage_Evolved_1_level_1_Projectile,
            20 => Mage_Evolved_1_level_2_Projectile,
            21 => Mage_Evolved_1_level_3_Projectile,
            22 => Mage_Evolved_2_level_1_Projectile,
            23 => Mage_Evolved_2_level_2_Projectile,
            24 => Mage_Evolved_2_level_3_Projectile,

            25 => man_With_Bow_Projectiles,
            26 => witch_Projectile,

            27 => others,
            _ => throw new()
        };
    }

    public Transform GetInstantiatedObjParent(int code)
    {
        return listsParent[code];
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

        Projectile projectile = Instantiate(GetProjectilePrefab(code), transform.position, Quaternion.identity, 
        GetInstantiatedObjParent(code)).GetComponent<Projectile>();
        
        GetProjectileList(code).Add(projectile);
        return projectile;
    }

    public Projectile GetProjectilePrefab(int code)
    {
        return projectilesPrefabs[code];
    }

}
