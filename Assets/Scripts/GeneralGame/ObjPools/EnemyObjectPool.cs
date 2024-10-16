using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyObjectPool : MonoBehaviour
{
    public static EnemyObjectPool Instance;

    [SerializeField] UnitValues[] enemyPrefabs;

    [SerializeField] Transform[] listsParent;

    List<UnitValues> crocodileList = new();
    List<UnitValues> deadShipList = new();
    List<UnitValues> giantList = new();
    List<UnitValues> goblinList = new();
    List<UnitValues> insecList = new();
    List<UnitValues> insec2List = new();
    List<UnitValues> manWithArrowList = new();
    List<UnitValues> manWithKnifeList = new();
    List<UnitValues> skeletonList = new();
    List<UnitValues> swampWitchList = new();
    List<UnitValues> turtleList = new();
    List<UnitValues> wolfList = new();
    List<UnitValues> bombList = new();
    List<UnitValues> manWithFlagList = new();

    void Awake() 
    {
        Instance = this;    
    }

    public List<UnitValues> GetEnemyList(int code)
    {
        return code switch
        {
            0 => crocodileList,
            1 => deadShipList,
            2 => giantList,
            3 => goblinList,
            4 => turtleList,
            5 => wolfList,
            6 => manWithArrowList,
            7 => manWithKnifeList,
            8 => skeletonList,
            9 => insec2List,
            10 => insecList,
            11 => swampWitchList,
            12 => bombList,
            13 => manWithFlagList,
            _ => throw new()
        };
    }

    public Transform GetInstantiatedObjParent(int code)
    {
        return listsParent[code];
    }

    public UnitValues GetEnemy(int code)
    {
        foreach (var item in GetEnemyList(code))
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

        UnitValues enemy = Instantiate(GetEnemyPrefab(code), transform.position, Quaternion.identity, 
        GetInstantiatedObjParent(code)).GetComponent<UnitValues>();

        GetEnemyList(code).Add(enemy);

        return enemy;
    }

    public UnitValues GetEnemyPrefab(int code)
    {
        return enemyPrefabs[code];
    }

}
