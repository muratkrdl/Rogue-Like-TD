using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainTower : MonoBehaviour
{
    [SerializeField] TowerInfoSo towerInfoSo;

    public TowerInfoSo GetTowerInfoSo
    {
        get => towerInfoSo;
    }

    void Start() 
    {
        Invoke(nameof(InvokeMainTowerSetHP), .1f);
    }

    void InvokeMainTowerSetHP()
    {
        GetComponent<TowerHealth>().SetTowerHealth(towerInfoSo.maxHealth + PermanentSkillSystem.Instance.GetPermanentSkillSO(11).Value);
    }

    public void OnMouseDownEvent()
    {
        InfoPanel.Instance.OnClickedTowerInfo?.Invoke(this, new() { towerInfoSo1 = towerInfoSo, isMainTower = true, tower = transform, underAttack = false } );
    }

}
