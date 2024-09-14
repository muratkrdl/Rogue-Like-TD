using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileOutPos : MonoBehaviour
{
    UnitMove unitMove;

    Vector2 value;

    void Start() 
    {
        unitMove = GetComponentInParent<UnitMove>();    
    }

    void Update()
    {
        value = new Vector2(Mathf.Sign(unitMove.GetLastDir.x), Mathf.Sign(unitMove.GetLastDir.y));
        
        transform.localPosition = new Vector2(-value.x / 4, -value.y / 10);
    }

}
