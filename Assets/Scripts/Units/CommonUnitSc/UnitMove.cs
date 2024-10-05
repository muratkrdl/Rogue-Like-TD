using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class UnitMove : MonoBehaviour
{
    [SerializeField] UnitValues unitValues;

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
        unitValues.GetNavMeshAgent().updateRotation = false;
        unitValues.GetNavMeshAgent().updateUpAxis = false;
    }

    void Update() 
    {
        if(unitValues.IsDead) return;
        if(unitValues.GetNavMeshAgent().velocity.x != 0 || unitValues.GetNavMeshAgent().velocity.y != 0 && !unitValues.IsAttacking)
        {
            lastDir = unitValues.GetNavMeshAgent().velocity;
        }
        if(Mathf.Abs(lastDir.x) > Mathf.Epsilon)
        {
            transform.localScale = new(-Mathf.Sign(lastDir.x), transform.localScale.y, transform.localScale.z);
        }
    }

    public void MoveUnit() 
    {
        if(!unitValues.GetNavMeshAgent().isStopped)
        {
            unitValues.GetNavMeshAgent().SetDestination(unitValues.GetEnemySetTarget().GetCurrentDestPos.position);
        }
    }

    public void StopUnit(bool isDying) 
    {
        if(!unitValues.GetNavMeshAgent().isStopped)
        {
            unitValues.GetNavMeshAgent().SetDestination(transform.position);

            if(isDying)
            {
                unitValues.GetEnemySetTarget().ChangeCurrentTarget(transform, false);
            }
            //  Vector2 offset = (unitValues.GetEnemySetTarget().GetCurrentDestPos.position - transform.position).normalized;
            //  offset += new Vector2(transform.position.x, transform.position.y /2);
            //  unitValues.GetNavMeshAgent().SetDestination(offset);
        }
    }

}
