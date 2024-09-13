using System;
using UnityEngine;
using UnityEngine.UI;

public class PlaceTower : MonoBehaviour
{
    [SerializeField] TowerInfoKeeper towerInfoKeeper;
    [SerializeField] PlaceTowerAnimation placeTowerAnimation;
    [SerializeField] LevelUpTower levelUpTower;

    [SerializeField] TowerChange[] towerChanges;

    [SerializeField] Image placeTowerCanvas;
    [SerializeField] Image levelUpTowerCanvas;

    [SerializeField] GameObject[] towers;

    void OnMouseDown() 
    {
        if(MainTowerManager.Instance.GetIsIn) return;
        placeTowerAnimation.ChangeAnimation();
        InfoPanel.Instance.OnClickedTowerInfo?.Invoke(this, new() { towerInfoSo1 = towerInfoKeeper.GetCurrentTowerInfo, tower = transform });
    }

    public void OnClick_BuildTower()
    {
        TowerInfoSo clickedTowerInfoSO = AllTowerInfos.Instance.GetTowerInfoSo(towerInfoKeeper.ClickedTowerCode, 1);
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

        clickedTowersAnimator.ResetTrigger(ConstStrings.TOWER_RESET);

        clickedTowersAnimator.SetTrigger(choosenAnimName);
        towerInfoKeeper.CurrentTowerLevel = 1;
        towerInfoKeeper.SetCurrentTowerInfo(towerInfoKeeper.ClickedTowerCode, towerInfoKeeper.CurrentTowerLevel);
        levelUpTower.UpdateTowerCostText();
        levelUpTower.SetAnimator = clickedTowersAnimator;
    }

    void OnClick_ChangeLevelUpCanvas()
    {
        GetComponent<BaseTowerPanelKeeper>().OpenCanvas(levelUpTowerCanvas);
        Invoke(nameof(ForInvokeSpriteRendererFalse), 1.5f);
    }

    void ForInvokeSpriteRendererFalse()
    {
        GetComponent<SpriteRenderer>().enabled = false;
    }

    void ForInvokeSpriteRendererTrue()
    {
        GetComponent<SpriteRenderer>().enabled = true;
    }

    public void ResetAllValues()
    {
        GetComponentInChildren<EvolvedBuildAnim>().PlayDestroyAnim();
        Invoke(nameof(ForInvokeSpriteRendererTrue), .5f);
        GetComponent<BaseTowerPanelKeeper>().OpenCanvas(placeTowerCanvas);
        foreach (var item in towers)
        {
            if(!item.activeSelf) continue;
            item.SetActive(false);
            item.GetComponent<Animator>().SetTrigger(ConstStrings.TOWER_RESET);
        }
        foreach (var item in towerChanges)
        {
            item.Reset();
        }

        levelUpTower.ResetAllValues();
        towerInfoKeeper.ResetAllValues();
    }

}
