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
        get => new(Mathf.Clamp(lastDir.x, -1, 1), Mathf.Clamp(lastDir.y, -1, 1f));
        set => lastDir = value;
    }

    void Start() 
    {
        unitValues.GetNavMeshAgent().updateRotation = false;
        unitValues.GetNavMeshAgent().updateUpAxis = false;
    }

    void Update() 
    {
        if(GameStateManager.Instance.GetIsGamePaused) return;

        if(unitValues.IsDead) return;

        if((unitValues.GetNavMeshAgent().velocity.x != 0 || unitValues.GetNavMeshAgent().velocity.y != 0) && !unitValues.IsAttacking)
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
            if(unitValues.GetIsEnemy)
                unitValues.GetNavMeshAgent().SetDestination(unitValues.GetEnemySetTarget().GetCurrentDestPos.position);
            else
                unitValues.GetNavMeshAgent().SetDestination(unitValues.GetGuardSetTarget().GetCurrentTarget.position);
        }
    }

    public void StopUnit(bool isDying) 
    {
        if(!unitValues.GetNavMeshAgent().isStopped)
        {
            if(isDying && unitValues.GetIsEnemy)
            {
                unitValues.GetEnemySetTarget().ChangeCurrentTarget(transform, false);
            }
            unitValues.GetNavMeshAgent().SetDestination(transform.position);
        }
    }

}
