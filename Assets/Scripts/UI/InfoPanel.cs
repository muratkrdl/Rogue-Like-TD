using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class InfoPanel : MonoBehaviour
{
    public static InfoPanel Instance;

    public EventHandler<OnClickedTowerInfoEventArg> OnClickedTowerInfo;
    public class OnClickedTowerInfoEventArg : EventArgs
    {
        public TowerInfoSo towerInfoSo1;
        public bool isMainTower;
        public Transform tower;
        public bool underAttack;
    }

    [SerializeField] Animator animator;

    [SerializeField] Image infoIcon;
    [SerializeField] TextMeshProUGUI infoName;
    [SerializeField] TextMeshProUGUI heartText;
    [SerializeField] TextMeshProUGUI damageText;

    [SerializeField] Image sellButton;
    [SerializeField] TextMeshProUGUI sellPriceText;
    [SerializeField] Image getInOutButton;

    TowerInfoSo currentTowerInfoSO;
    TowerHealth currentTowerHealth;

    bool isIn = false;

    public TowerInfoSo GetCurrentTowerInfoSO
    {
        get => currentTowerInfoSO;
    }

    void Awake() 
    {
        Instance = this;
    }

    void Start() 
    {
        OnClickedTowerInfo += InfoPanel_OnClickedTowerInfo;
    }

    void OnDestroy() 
    {
        OnClickedTowerInfo -= InfoPanel_OnClickedTowerInfo;
    }

    void InfoPanel_OnClickedTowerInfo(object sender, OnClickedTowerInfoEventArg e)
    {
        if(e.towerInfoSo1 == null || e.underAttack && !isIn)
        {
            SetInfoPanelAnim(false);
            return;
        }

        if(e.underAttack && isIn)
        {
            if(currentTowerHealth == e.tower.GetComponent<TowerHealth>())
                UpdateHP();
            return;
        } 
        
        if(e.tower.TryGetComponent<TowerHealth>(out var towerHealth))
        {
            currentTowerHealth = towerHealth;
        }

        SetInfoPanelAnim(true);

        currentTowerInfoSO = e.towerInfoSo1;

        infoIcon.sprite = currentTowerInfoSO.towerImageIcon;
        infoName.text = currentTowerInfoSO.Name;

        heartText.text = currentTowerHealth.GetCurrentHealth.ToString();

        damageText.text = currentTowerInfoSO.BaseDamageRange.x.ToString() + "-" + currentTowerInfoSO.BaseDamageRange.y.ToString();
        damageText.color = currentTowerInfoSO.DamageTypeColor;

        sellButton.gameObject.SetActive(!e.isMainTower);
        getInOutButton.gameObject.SetActive(e.isMainTower);
        sellPriceText.text = currentTowerInfoSO.sellPrice.ToString();
    }

    public void UpdateHP()
    {
        heartText.text = currentTowerHealth.GetCurrentHealth.ToString();
    }

    public void OnClick_SellButton()
    {
        if(LMouseClick.Instance.GetLastClickedTower.GetComponent<TowerInfoKeeper>().GetCurrentTowerCode == -1) return;
        
        LMouseClick.Instance.GetLastClickedTower.ResetAllValues();
        Bank.Instance.OnChangeMoneyAmount?.Invoke(this, new() { amount = currentTowerInfoSO.sellPrice } );
    }

    public void OnClick_InOut()
    {
        if(GlobalUnitTargets.Instance.GetPlayerTarget().GetComponent<PlayerHealth>().GetIsDead) return;
        MainTowerManager.Instance.OnInteractWithMainTower?.Invoke(this, EventArgs.Empty);
        GlobalUnitTargets.Instance.GetPlayerTarget().GetComponent<Animator>().SetTrigger(ConstStrings.UNIT_ANIMATOR_RESPAWN);
    }

    public void SetInfoPanelAnim(bool value)
    {
        if(!value && isIn)
        {
            animator.SetTrigger(ConstStrings.INFO_PANEL_ANIMATOR_OUT);
        }
        else if(value)
        {
            animator.SetTrigger(ConstStrings.INFO_PANEL_ANIMATOR_IN);
        }

        isIn = value;
    }

}
