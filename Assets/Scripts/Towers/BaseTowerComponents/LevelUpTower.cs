using System.Net.Http.Headers;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelUpTower : MonoBehaviour
{
    [SerializeField] TowerInfoKeeper towerInfoKeeper;
    [SerializeField] EvolvedBuildAnim evolvedBuildAnim;
    [SerializeField] TowerInfo levelUpTowerInfo;

    [SerializeField] TextMeshProUGUI costText;

    [SerializeField] GameObject evolveTowerCanvas;

    [SerializeField] TowerInfo firstEvolveInfoPanel;
    [SerializeField] TowerInfo secondEvolveInfoPanel;

    [SerializeField] Image levelUpTowerIcon;

    [SerializeField] float evolvedTowerIconX;
    [SerializeField] float evolvedTowerIconTransformY;

    [SerializeField] Animator[] units;

    Animator animator;
    Animator choosenUnitAnimator;

    float initialNormalTowerIconX;
    float initialNormalTowerIconY;
    float initialNormalTowerIconTransformY;

    public Animator Animator
    {
        get => animator;
        set => animator = value;
    }

    public Animator GetChoosenUnitAnimator
    {
        get
        {
            return choosenUnitAnimator;
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

        TowerInfoSo clickedNextLevelTowerInfo = AllTowerInfos.Instance.GetTowerInfoSo(towerInfoKeeper.GetCurrentTowerCode, towerInfoKeeper.CurrentTowerLevel + 1);
        if(!Bank.Instance.CanUseMoney(clickedNextLevelTowerInfo.towerCost)) return;

        Bank.Instance.OnChangeMoneyAmount?.Invoke(this, new() { amount = -clickedNextLevelTowerInfo.towerCost });

        if(towerInfoKeeper.GetCurrentTowerCode > 3)
        {
            evolvedBuildAnim.PlayBuildAnim();
            SoundManager.Instance.PlaySound2DVolume(ConstStrings.TOWERLEVELUPEVOLVE, .75f);
        }
        else
        {
            SoundManager.Instance.PlaySound2DVolume(ConstStrings.TOWERLEVELUP, .7f);
        }

        animator.SetTrigger(ConstStrings.ANIM);
        if(choosenUnitAnimator != null)
            choosenUnitAnimator.SetTrigger(ConstStrings.ANIM);
        Invoke(nameof(UpdateTowerInfoSO), .1f);
    }

    void UpdateTowerInfoSO()
    {
        towerInfoKeeper.CurrentTowerLevel += 1;
        towerInfoKeeper.SetCurrentTowerInfo(towerInfoKeeper.GetCurrentTowerCode, towerInfoKeeper.CurrentTowerLevel);

        if(towerInfoKeeper.GetCurrentTowerCode > 3 && towerInfoKeeper.CurrentTowerLevel == 3)
        {
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

        InfoPanel.Instance.OnClickedTowerInfo?.Invoke(this, new() { isMainTower = false, towerInfoSo1 = towerInfoKeeper.GetCurrentTowerInfo, tower = transform, underAttack = false } );
        UpdateTowerCostText();
    }

    void SetInfoEvovlvePanelsValues()
    {
        int firstTowerCode = (towerInfoKeeper.GetCurrentTowerCode +2) * 2;

        firstEvolveInfoPanel.SetTowerInfoSo(AllTowerInfos.Instance.GetTowerInfoSo(firstTowerCode, 1));
        secondEvolveInfoPanel.SetTowerInfoSo(AllTowerInfos.Instance.GetTowerInfoSo(firstTowerCode +1, 1));
    }

    public void UpdateTowerCostText()
    {
        TowerInfoSo nextLevelTowerInfo = AllTowerInfos.Instance.GetTowerInfoSo(towerInfoKeeper.GetCurrentTowerCode, towerInfoKeeper.CurrentTowerLevel + 1);
        costText.text = nextLevelTowerInfo.towerCost.ToString();
        levelUpTowerInfo.SetTowerInfoSo(nextLevelTowerInfo);
    }

    public void ResetAllValues()
    {
        if(animator == null) return;
        animator.SetTrigger(ConstStrings.RESET);
        Animator = null;
        levelUpTowerIcon.rectTransform.sizeDelta = new(initialNormalTowerIconX, initialNormalTowerIconY);
        levelUpTowerIcon.rectTransform.localPosition = new(levelUpTowerIcon.rectTransform.localPosition.x, initialNormalTowerIconTransformY);
        choosenUnitAnimator.SetTrigger(ConstStrings.RESET);
        if(towerInfoKeeper.GetCurrentTowerCode != 2 && towerInfoKeeper.GetCurrentTowerCode != 8 && towerInfoKeeper.GetCurrentTowerCode != 9)
        {
            choosenUnitAnimator.GetComponent<TowerUnitValues>().GetTowerUnitStateController().ChangeState(new TowerUnitIdleState());
            choosenUnitAnimator.GetComponent<TowerUnitValues>().GetTowerUnitSetTarget().SetTargetToBaseTarget();
        }
        choosenUnitAnimator.gameObject.SetActive(false);
    }

    public void SetChoosenUnitAnimator(int code, string str)
    {
        int realCode = code;
        if(code > 3)
        {
            realCode = code switch
            {
                5 => 4,
                6 => 5,
                7 => 5,
                8 => 6,
                9 => 6,
                10 => 7,
                11 => 7,
                _ => 4,
            };
        }
        units[realCode].gameObject.SetActive(true);
        choosenUnitAnimator = units[realCode];
        if(code > 3)
        {
            choosenUnitAnimator.SetTrigger(str);
        }
    }

}
