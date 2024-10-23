using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveProjectileMove : MonoBehaviour
{
    [SerializeField] ActiveProjectile activeProjectile;

    void Start()
    {
        GetComponent<Rigidbody2D>().AddForce(activeProjectile.GetLookPos.normalized * 300);
    }

}
