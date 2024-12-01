using System.Collections;
using System.Collections.Generic;
using System.IO.Compression;
using UnityEngine;

public class UnitPause : GamePlayMonoBehaviour
{
    protected override void PostPause()
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }
}
