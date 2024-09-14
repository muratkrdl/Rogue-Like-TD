using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllProjectileSOs : MonoBehaviour
{
    public static AllProjectileSOs Instance;

    [SerializeField] ProjectiileSO[] projectiileSOs;

    void Awake() 
    {
        Instance = this;
    }

    public ProjectiileSO GetProjectiileSO(int value)
    {
        return projectiileSOs[value];
    }
}
