using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerUnitSetTarget : MonoBehaviour
{
    [SerializeField] Transform fornow;

    void Start() 
    {
        ChangeCurrentTarget(fornow);    
    }

    [SerializeField] TowerUnitValues towerUnitValues;

    [SerializeField] Transform origin;

    Transform currentTarget;

    Vector2 lastDir = Vector2.down;

    public Vector2 GetLastDir
    {
        get
        {
            return lastDir.normalized;
        }
    }

    public Transform GetCurrentTarget
    {
        get
        {
            return currentTarget;
        }
    }

    void Update() 
    {
        // if(!towerUnitValues.IsAttacking) return;

        lastDir = currentTarget.position - origin.position;

        if(Mathf.Abs(lastDir.x) > Mathf.Epsilon)
        {
            transform.localScale = new(-Mathf.Sign(lastDir.x), transform.localScale.y, transform.localScale.z);
        }
    }

    public void ChangeCurrentTarget(Transform changeTransform)
    {
        currentTarget = changeTransform;
    }

}
