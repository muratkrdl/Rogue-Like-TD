using System;
using UnityEngine;
using UnityEngine.UI;

public class PlaceTower : MonoBehaviour
{
    [SerializeField] TowerInfoKeeper towerInfoKeeper;
    [SerializeField] PlaceTowerAnimation placeTowerAnimation;
    [SerializeField] LevelUpTower levelUpTower;

    [SerializeField] Image placeTowerCanvas;

    [SerializeField] Image levelUpTowerCanvas;

    [SerializeField] GameObject[] towers;

    void OnMouseDown() 
    {
        if(MainTowerManager.Instance.GetIsIn) return;

        placeTowerAnimation.ChangeAnimation();
        InfoPanel.Instance.OnClickedTowerInfo?.Invoke(this, new() { towerInfoSo1 = towerInfoKeeper.GetCurrentTowerInfo });
    }

    public void OnClick_BuildTower(int i)
    {
        TowerInfoSo clickedTowerInfoSO = towerInfoKeeper.GetTowerInfoSo(i, 1);
        if(!Bank.Instance.CanUseMoney(clickedTowerInfoSO.towerCost)) return;
        
        Bank.Instance.OnChangeMoneyAmount?.Invoke(this, new() { amount = -clickedTowerInfoSO.towerCost } );

        OnClick_ChangeLevelUpCanvas();

        Animator clickedTowersAnimator = towers[i].GetComponentInChildren<Animator>();

        towers[i].SetActive(true);
        clickedTowersAnimator.SetTrigger(ConstStrings.TOWER_LEVEL_UP);
        towerInfoKeeper.SetCurrentTowerInfo(i, 1);
        levelUpTower.UpdateTowerCostText();
        levelUpTower.SetAnimator = clickedTowersAnimator;
    }

    void OnClick_ChangeLevelUpCanvas()
    {
        placeTowerCanvas.gameObject.SetActive(false);
        levelUpTowerCanvas.gameObject.SetActive(true);
        Invoke(nameof(ForInvokeSpriteRenderer), 1.5f);
    }

    void ForInvokeSpriteRenderer()
    {
        GetComponent<SpriteRenderer>().enabled = false;
    }

}
