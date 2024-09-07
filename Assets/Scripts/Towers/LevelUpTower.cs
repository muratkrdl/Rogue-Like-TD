using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class LevelUpTower : MonoBehaviour
{
    [SerializeField] TowerInfoKeeper towerInfoKeeper;
    [SerializeField] EvolvedBuildAnim evolvedBuildAnim;
    [SerializeField] TowerInfo levelUpTowerInfo;

    [SerializeField] TextMeshProUGUI costText;

    [SerializeField] Image evolveTowerCanvas;

    [SerializeField] TowerInfo firstEvolveInfoPanel;
    [SerializeField] TowerInfo secondEvolveInfoPanel;

    [SerializeField] Image levelUpTowerIcon;

    [SerializeField] float evolvedTowerIconX;
    [SerializeField] float evolvedTowerIconTransformY;

    Animator animator;

    float initialNormalTowerIconX;
    float initialNormalTowerIconY;
    float initialNormalTowerIconTransformY;

    bool isTowerFull = false;

    public bool GetIsTowerFull
    {
        get
        {
            return isTowerFull;
        }
    }

    public Animator SetAnimator
    {
        set
        {
            animator = value;
        }
    }

    void Start() 
    {
        initialNormalTowerIconX = levelUpTowerIcon.rectTransform.sizeDelta.x;
        initialNormalTowerIconY = levelUpTowerIcon.rectTransform.sizeDelta.y;
        initialNormalTowerIconTransformY = levelUpTowerIcon.rectTransform.localPosition.y;
    }

    public void OnClick_LevelUpTower()
    {
        if(GetComponentInChildren<EvolvedBuildAnim>().GetIsBusy) return;

        TowerInfoSo clickedNextLevelTowerInfo = towerInfoKeeper.GetTowerInfoSo(towerInfoKeeper.GetCurrentTowerCode, towerInfoKeeper.CurrentTowerLevel + 1);
        if(!Bank.Instance.CanUseMoney(clickedNextLevelTowerInfo.towerCost)) return;

        Bank.Instance.OnChangeMoneyAmount?.Invoke(this, new() { amount = -clickedNextLevelTowerInfo.towerCost });

        if(towerInfoKeeper.GetCurrentTowerCode > 3)
        {
            evolvedBuildAnim.PlayBuildAnim();
        }

        animator.SetTrigger(ConstStrings.TOWER_LEVEL_UP);
        Invoke(nameof(UpdateTowerInfoSO), .1f);
    }

    void UpdateTowerInfoSO()
    {
        towerInfoKeeper.CurrentTowerLevel += 1;
        towerInfoKeeper.SetCurrentTowerInfo(towerInfoKeeper.GetCurrentTowerCode, towerInfoKeeper.CurrentTowerLevel);

        if(towerInfoKeeper.GetCurrentTowerCode > 3 && towerInfoKeeper.CurrentTowerLevel == 3)
        {
            isTowerFull = true;
            GetComponent<BaseTowerPanelKeeper>().CloseAllCanvas();
            return;
        }

        if(towerInfoKeeper.CurrentTowerLevel == 4)
        {
            GetComponent<BaseTowerPanelKeeper>().OpenCanvas(evolveTowerCanvas);
            SetInfoEvovlvePanelsValues();
            levelUpTowerIcon.rectTransform.sizeDelta = new(evolvedTowerIconX, evolvedTowerIconX * 2);
            levelUpTowerIcon.rectTransform.localPosition = new(levelUpTowerIcon.rectTransform.localPosition.x, evolvedTowerIconTransformY);
            return;
        }

        InfoPanel.Instance.OnClickedTowerInfo?.Invoke(this, new() { isMainTower = false, towerInfoSo1 = towerInfoKeeper.GetCurrentTowerInfo } );
        UpdateTowerCostText();
    }

    void SetInfoEvovlvePanelsValues()
    {
        int firstTowerCode = (towerInfoKeeper.GetCurrentTowerCode +2) * 2;

        firstEvolveInfoPanel.SetTowerInfoSo(towerInfoKeeper.GetTowerInfoSo(firstTowerCode, 1));
        secondEvolveInfoPanel.SetTowerInfoSo(towerInfoKeeper.GetTowerInfoSo(firstTowerCode +1, 1));
    }

    public void UpdateTowerCostText()
    {
        TowerInfoSo nextLevelTowerInfo = towerInfoKeeper.GetTowerInfoSo(towerInfoKeeper.GetCurrentTowerCode, towerInfoKeeper.CurrentTowerLevel + 1);
        costText.text = nextLevelTowerInfo.towerCost.ToString();
        levelUpTowerInfo.SetTowerInfoSo(nextLevelTowerInfo);
    }

    public void ResetAllValues()
    {
        SetAnimator = null;
        levelUpTowerIcon.rectTransform.sizeDelta = new(initialNormalTowerIconX, initialNormalTowerIconY);
        levelUpTowerIcon.rectTransform.localPosition = new(levelUpTowerIcon.rectTransform.localPosition.x, initialNormalTowerIconTransformY);
        isTowerFull = false;
    }

}
