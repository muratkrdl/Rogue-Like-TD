using System.Collections;
using System.Collections.Generic;
using System.IO.Compression;
using UnityEngine;

public class UnitPause : GamePlayMonoBehaviour
{
    void Start() 
    {
        if(GetPauseable)
            SubscribeToEvents();
    }

    protected override void PostPause()
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }

    void OnDestroy() 
    {
        if(GetPauseable)
            UnSubscribeToEvents();
    }

}
