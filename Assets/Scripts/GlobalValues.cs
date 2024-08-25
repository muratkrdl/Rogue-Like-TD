using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalValues : MonoBehaviour
{
    public static GlobalValues Instance;

    float initialDeltaTime;
    float initialFixedDeltaTime;

    float currentDeltaTime;
    float currentFixedDeltaTime;

    public float GetDeltaTime
    {
        get
        {
            return currentDeltaTime;
        }
    }

    public float GetFixedDeltaTime
    {
        get
        {
            return currentFixedDeltaTime;
        }
    }

    void Awake() 
    {
        Instance = this; 
    }

    void Start()
    {
        initialDeltaTime = Time.deltaTime;
        currentDeltaTime = initialDeltaTime;
        initialFixedDeltaTime = Time.fixedDeltaTime;
        currentFixedDeltaTime = initialFixedDeltaTime;
    }

}
