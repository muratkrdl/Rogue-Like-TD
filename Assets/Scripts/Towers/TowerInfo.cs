using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TowerInfo : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] TowerInfoSo towerInfoSO;

    [SerializeField] TextMeshProUGUI towerNameText;
    [SerializeField] TextMeshProUGUI baseDamageRangeText;
    [SerializeField] TextMeshProUGUI descriptionText;
    [SerializeField] TextMeshProUGUI towerCostText;
    [SerializeField] Image rangeCircle;
    [SerializeField] Image towerIcon;

    [SerializeField] GameObject InfosParent;

    void Start() 
    {
        SetTowerInfoSOValuesToCanvas();
    }

    void SetTowerInfoSOValuesToCanvas()
    {
        towerNameText.text = towerInfoSO.Name;
        baseDamageRangeText.text = towerInfoSO.BaseDamageRange.x.ToString() + "-" + towerInfoSO.BaseDamageRange.y.ToString();
        baseDamageRangeText.color = towerInfoSO.DamageTypeColor;
        rangeCircle.transform.localScale = new(towerInfoSO.Range, towerInfoSO.Range);
        descriptionText.text = towerInfoSO.Description;
        towerCostText.text = towerInfoSO.towerCost.ToString();
        towerIcon.sprite = towerInfoSO.towerIcon;
    }

    public void SetTowerInfoSo(TowerInfoSo newInfo)
    {
        towerInfoSO = newInfo;
        SetTowerInfoSOValuesToCanvas();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        SetInfoParentObject(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        SetInfoParentObject(false);
    }

    public void SetInfoParentObject(bool value)
    {
        if(InfosParent.activeSelf == value) return;
        InfosParent.SetActive(value);
    }

}
