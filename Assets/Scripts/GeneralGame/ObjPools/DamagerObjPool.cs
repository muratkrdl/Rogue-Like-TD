using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagerObjPool : MonoBehaviour
{
    public static DamagerObjPool Instance;

    [SerializeField] DamageForEvolvedTowerProjectile[] damagerObjPrefabs;

    [SerializeField] Transform[] listsParent;

    List<DamageForEvolvedTowerProjectile> damager1 = new();
    List<DamageForEvolvedTowerProjectile> damager2 = new();
    List<DamageForEvolvedTowerProjectile> damager3 = new();

    void Awake() 
    {
        Instance = this;    
    }

    List<DamageForEvolvedTowerProjectile> GetDamagerObjList(int code)
    {
        return code switch
        {
            0 => damager1,
            1 => damager2,
            _ => damager3
        };
    }

    Transform GetInstantiatedObjParent(int code)
    {
        return listsParent[code];
    }

    public DamageForEvolvedTowerProjectile GetDamagerObj(int code)
    {
        foreach(var item in GetDamagerObjList(code))
        {
            if(!item.IsAvailable)
            {
                return item;
            }
        }

        DamageForEvolvedTowerProjectile damagerObj = Instantiate(GetDamagerObjPrefab(code), transform.position, Quaternion.identity, 
        GetInstantiatedObjParent(code)).GetComponent<DamageForEvolvedTowerProjectile>();

        GetDamagerObjList(code).Add(damagerObj);

        return damagerObj;
    }

    DamageForEvolvedTowerProjectile GetDamagerObjPrefab(int code)
    {
        return damagerObjPrefabs[code];
    }
}
