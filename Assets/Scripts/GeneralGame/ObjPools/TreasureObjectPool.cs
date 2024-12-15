using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureObjectPool : MonoBehaviour
{
    public static TreasureObjectPool Instance;

    void Awake() 
    {
        Instance = this;    
    }

    [SerializeField] TreasureObject treasureObjectPrefabs;

    [SerializeField] Transform listsParent;

    List<TreasureObject> treasure1 = new();

    List<TreasureObject> GetTreasureObjList()
    {
        return treasure1;
    }

    Transform GetInstantiatedObjParent()
    {
        return listsParent;
    }

    public TreasureObject GetTreasureObj()
    {
        foreach(var item in GetTreasureObjList())
        {
            if(!item.GetIsAvaliable)
            {
                return item;
            }
        }

        TreasureObject treasureObj = Instantiate(GetTreasureObjPrefab(), transform.position, Quaternion.identity, 
        GetInstantiatedObjParent()).GetComponent<TreasureObject>();

        GetTreasureObjList().Add(treasureObj);

        return treasureObj;
    }

    TreasureObject GetTreasureObjPrefab()
    {
        return treasureObjectPrefabs;
    }

}
