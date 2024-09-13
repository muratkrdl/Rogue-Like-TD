using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalUnitTargets : MonoBehaviour
{
    public static GlobalUnitTargets Instance;
    
    [SerializeField] Transform[] towersPos;
    [SerializeField] Transform mainTower;
    [SerializeField] Transform playerTarget;

    void Awake() 
    {
        Instance = this;    
    }

    public Transform[] GetTowersPos()
    {
        return towersPos;
    }

    public Transform GetMainTower()
    {
        return mainTower;
    }

    public Transform GetPlayerTarget()
    {
        return playerTarget;
    }
}
