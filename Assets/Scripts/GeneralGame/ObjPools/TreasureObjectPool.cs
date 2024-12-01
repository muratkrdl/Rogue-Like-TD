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

    [SerializeField] TreasureObject[] treasureObjectPrefabs;

    [SerializeField] Transform[] listsParent;

    List<TreasureObject> treasure1 = new();

    List<TreasureObject> GetTreasureObjList(int code)
    {
        return code switch
        {
            0 => treasure1,
            _ => throw new System.NotImplementedException(),
        };
    }

    Transform GetInstantiatedObjParent(int code)
    {
        return listsParent[code];
    }

    public TreasureObject GetTreasureObj(int code)
    {
        foreach(var item in GetTreasureObjList(code))
        {
            if(!item.GetIsAvaliable)
            {
                return item;
            }
        }

        TreasureObject damagerObj = Instantiate(GetTreasureObjPrefab(code), transform.position, Quaternion.identity, 
        GetInstantiatedObjParent(code)).GetComponent<TreasureObject>();

        GetTreasureObjList(code).Add(damagerObj);

        return damagerObj;
    }

    TreasureObject GetTreasureObjPrefab(int code)
    {
        return treasureObjectPrefabs[code];
    }

}
