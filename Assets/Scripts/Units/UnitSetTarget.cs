using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSetTarget : MonoBehaviour
{
    [SerializeField] UnitValues unitValues;
    Transform currentTarget;

    [SerializeField] Transform go;

    public Transform GetCurrentTarget
    {
        get
        {
            return currentTarget;
        }
    }

    void Start() 
    {
        ChangeCurrentTarget(go);
    }
    
    public void CheckClosePlayerandTower() // singleton bir yapıya parametreler girdirerek kullan
    {
        if(unitValues.IsChasing) return;
        
        if(Mathf.Abs(Vector2.Distance(transform.position, GlobalUnitTargets.Instance.GetPlayerTarget().position)) <= unitValues.EnemySO.AttackRange + 2)
        {
            ChangeCurrentTarget(GlobalUnitTargets.Instance.GetPlayerTarget());
            unitValues.IsChasing = true;
        }
        else
        {
            foreach (var item in GlobalUnitTargets.Instance.GetTowersPos())
            {
                if(item.GetComponent<TowerInfoKeeper>().GetCurrentTowerCode == -1) continue;
                if(Mathf.Abs(Vector2.Distance(transform.position, item.position)) <= unitValues.EnemySO.AttackRange + 2)
                {
                    unitValues.IsChasing = true;
                    // kulenin vurma yerlerine doğru ilerlesin
                    ChangeCurrentTarget(item);
                    break;
                }
                else
                {
                    continue;
                }
            }
        }
    }

    public void SetCurrentTargetToMainTower()
    {
        currentTarget = GlobalUnitTargets.Instance.GetMainTower();
    }

    public void ChangeCurrentTarget(Transform changeTransform)
    {
        currentTarget = changeTransform;
    }
}
