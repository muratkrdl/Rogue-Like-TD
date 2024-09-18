using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class UnitMove : MonoBehaviour
{
    [SerializeField] UnitValues unitValues;

    NavMeshAgent navMeshAgent;

    Vector2 lastDir;

    public Vector2 LastDir
    {
        get
        {
            // return new Vector2(Mathf.Sign(lastDir.x), Mathf.Sign(lastDir.y));
            return new Vector2(Mathf.Clamp(lastDir.x, -1, 1), Mathf.Clamp(lastDir.y, -1, 1f));
        }
        set
        {
            lastDir = value;
        }
    }

    void Start() 
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.updateRotation = false;
        navMeshAgent.updateUpAxis = false;
    }

    void Update() 
    {
        if(navMeshAgent.velocity.x != 0 || navMeshAgent.velocity.y != 0 && !unitValues.IsAttacking)
        {
            lastDir = navMeshAgent.velocity;
        }
        if(Mathf.Abs(lastDir.x) > Mathf.Epsilon)
        {
            transform.localScale = new(-Mathf.Sign(lastDir.x), transform.localScale.y, transform.localScale.z);
        }
    }

    public void MoveUnit() 
    {
        if(!navMeshAgent.isStopped)
        {
            navMeshAgent.SetDestination(unitValues.GetUnitSetTarget().GetCurrentDestPos.position);
        }
    }

    public void StopUnit() 
    {
        if(!navMeshAgent.isStopped)
        {
            Vector2 offset = (unitValues.GetUnitSetTarget().GetCurrentDestPos.position - transform.position).normalized /2;
            offset += new Vector2(transform.position.x, transform.position.y);
            navMeshAgent.SetDestination(offset);
        }
    }
}
