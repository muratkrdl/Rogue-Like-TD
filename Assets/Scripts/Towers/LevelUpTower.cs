using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelUpTower : MonoBehaviour
{
    [SerializeField] TowerInfoKeeper towerInfoKeeper;
    [SerializeField] TowerInfo levelUpTowerInfo;

    [SerializeField] TextMeshProUGUI costText;

    Animator animator;

    public Animator SetAnimator
    {
        set
        {
            animator = value;
        }
    }

    public void OnClick_LevelUpTower()
    {
        TowerInfoSo clickedNextLevelTowerInfo = towerInfoKeeper.GetTowerInfoSo(towerInfoKeeper.GetCurrentTowerCode, towerInfoKeeper.CurrentTowerLevel + 1);
        if(!Bank.Instance.CanUseMoney(clickedNextLevelTowerInfo.towerCost)) return;

        Bank.Instance.OnChangeMoneyAmount?.Invoke(this, new() { amount = -clickedNextLevelTowerInfo.towerCost });

        animator.SetTrigger(ConstStrings.TOWER_LEVEL_UP);
        Invoke(nameof(UpdateTowerInfoSO), .1f);
    }

    void UpdateTowerInfoSO()
    {
        towerInfoKeeper.SetCurrentTowerInfo(towerInfoKeeper.GetCurrentTowerCode, towerInfoKeeper.CurrentTowerLevel + 1);
        towerInfoKeeper.CurrentTowerLevel += 1;
        UpdateTowerCostText();
    }

    public void UpdateTowerCostText()
    {
        TowerInfoSo nextLevelTowerInfo = towerInfoKeeper.GetTowerInfoSo(towerInfoKeeper.GetCurrentTowerCode, towerInfoKeeper.CurrentTowerLevel + 1);
        costText.text = nextLevelTowerInfo.towerCost.ToString();
        levelUpTowerInfo.SetTowerInfoSo(nextLevelTowerInfo);
    }

}
