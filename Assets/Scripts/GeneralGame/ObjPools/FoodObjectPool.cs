using System.Collections.Generic;
using UnityEngine;

public class FoodObjectPool : MonoBehaviour
{
    public static FoodObjectPool Instance;

    void Awake() 
    {
        Instance = this;    
    }

    [SerializeField] GameObject foodObjectPrefab;

    [SerializeField] Transform listsParent;

    List<GameObject> foodList = new();

    List<GameObject> GetFoodObjList()
    {
        return foodList;
    }

    Transform GetInstantiatedObjParent()
    {
        return listsParent;
    }

    public GameObject GetFoodObj()
    {
        foreach(var item in GetFoodObjList())
        {
            if(!item.activeSelf)
                return item;
        }

        GameObject obj = Instantiate(GetFoodObjPrefab(), transform.position, Quaternion.identity, GetInstantiatedObjParent());

        GetFoodObjList().Add(obj);

        return obj;
    }

    GameObject GetFoodObjPrefab()
    {
        return foodObjectPrefab;
    }

}
