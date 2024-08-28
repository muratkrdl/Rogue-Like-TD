using System;
using UnityEngine;
using UnityEngine.UI;

public class PlaceTower : MonoBehaviour
{
    [SerializeField] TowerInfoKeeper towerInfoKeeper;
    [SerializeField] PlaceTowerAnimation placeTowerAnimation;
    [SerializeField] LevelUpTower levelUpTower;

    [SerializeField] Image levelUpTowerCanvas;

    [SerializeField] GameObject[] towers;

    void OnMouseDown() 
    {
        if(MainTowerManager.Instance.GetIsIn) return;
        placeTowerAnimation.ChangeAnimation();
        InfoPanel.Instance.OnClickedTowerInfo?.Invoke(this, new() { towerInfoSo1 = towerInfoKeeper.GetCurrentTowerInfo });
    }

    public void OnClick_BuildTower()
    {
        TowerInfoSo clickedTowerInfoSO = towerInfoKeeper.GetTowerInfoSo(towerInfoKeeper.ClickedTowerCode, 1);
        if(!Bank.Instance.CanUseMoney(clickedTowerInfoSO.towerCost)) return;
        
        Bank.Instance.OnChangeMoneyAmount?.Invoke(this, new() { amount = -clickedTowerInfoSO.towerCost } );

        placeTowerAnimation.CloseAnimation();
        OnClick_ChangeLevelUpCanvas();

        Animator clickedTowersAnimator;
        string choosenAnimName = ConstStrings.TOWER_LEVEL_UP;

        if(towerInfoKeeper.ClickedTowerCode <= 3)
        {
            clickedTowersAnimator = towers[towerInfoKeeper.ClickedTowerCode].GetComponent<Animator>();
            towers[towerInfoKeeper.ClickedTowerCode].SetActive(true);
        }
        else
        {
            TowerChange closeTowerChange = towers[towerInfoKeeper.GetCurrentTowerCode].GetComponent<TowerChange>();
            clickedTowersAnimator = closeTowerChange.GetOpenTower.GetComponent<Animator>();
            closeTowerChange.ChangeTower();
            if(towerInfoKeeper.ClickedTowerCode % 2 == 0)
            {
                choosenAnimName = ConstStrings.TOWER_LEVEL_UP_EVOLVE1;
            }
            else
            {
                choosenAnimName = ConstStrings.TOWER_LEVEL_UP_EVOLVE2;
            }

            GetComponentInChildren<EvolvedBuildAnim>().PlayBuildAnim();
        }

        clickedTowersAnimator.SetTrigger(choosenAnimName);
        towerInfoKeeper.CurrentTowerLevel = 1;
        towerInfoKeeper.SetCurrentTowerInfo(towerInfoKeeper.ClickedTowerCode, towerInfoKeeper.CurrentTowerLevel);
        levelUpTower.UpdateTowerCostText();
        levelUpTower.SetAnimator = clickedTowersAnimator;
    }

    void OnClick_ChangeLevelUpCanvas()
    {
        GetComponent<BaseTowerPanelKeeper>().OpenCanvas(levelUpTowerCanvas);
        Invoke(nameof(ForInvokeSpriteRenderer), 1.5f);
    }

    void ForInvokeSpriteRenderer()
    {
        GetComponent<SpriteRenderer>().enabled = false;
    }

}
