using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExperienceObjectPool : MonoBehaviour
{
    public static ExperienceObjectPool Instance;

    [SerializeField] GameObject[] experienceObjPrefabs;

    [SerializeField] Transform[] listsParent;

    List<Transform> experienceObj1 = new();
    List<Transform> experienceObj2 = new();
    List<Transform> experienceObj3 = new();

    void Awake() 
    {
        Instance = this;    
    }

    List<Transform> GetExperienceObjList(int code)
    {
        return code switch
        {
            0 => experienceObj1,
            1 => experienceObj2,
            _ => experienceObj3
        };
    }

    Transform GetInstantiatedObjParent(int code)
    {
        return listsParent[code];
    }

    public Transform GetExperienceObj(int code)
    {
        foreach (var item in GetExperienceObjList(code))
        {
            if(!item.gameObject.activeSelf)
            {
                return item;
            }
            else
            {
                continue;
            }
        }

        Transform experienceObj = Instantiate(GetExperienceObjPrefab(code), transform.position, Quaternion.identity, 
        GetInstantiatedObjParent(code)).transform;

        GetExperienceObjList(code).Add(experienceObj);

        return experienceObj;
    }

    GameObject GetExperienceObjPrefab(int code)
    {
        return experienceObjPrefabs[code];
    }
}
