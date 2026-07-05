using System.Collections.Generic;
using UnityEngine;

public class GuardUnitObjectPool : MonoBehaviour
{
    public static GuardUnitObjectPool Instance;

    [SerializeField] UnitValues[] guardPrefabs;
    [SerializeField] Transform[] listsParent;

    List<UnitValues>[] guardLists;

    void Awake()
    {
        Instance = this;
        guardLists = new List<UnitValues>[guardPrefabs.Length];
        for (int i = 0; i < guardPrefabs.Length; i++)
        {
            guardLists[i] = new List<UnitValues>();
        }
    }

    List<UnitValues> GetGuardList(int code)
    {
        return guardLists[code];
    }

    Transform GetInstantiatedObjParent(int code)
    {
        return listsParent[code];
    }

    public UnitValues GetGuard(int code)
    {
        foreach (var item in GetGuardList(code))
        {
            if (item.IsWaiting)
                return item;
        }

        UnitValues guard = Instantiate(GetGuardPrefab(code), transform.position, Quaternion.identity,
            GetInstantiatedObjParent(code)).GetComponent<UnitValues>();

        GetGuardList(code).Add(guard);

        return guard;
    }

    UnitValues GetGuardPrefab(int code)
    {
        return guardPrefabs[code];
    }

    public bool CheckAllGuardDied(int code)
    {
        foreach (var item in GetGuardList(code))
        {
            if (!item.IsDead)
                return false;
        }

        return true;
    }
}
