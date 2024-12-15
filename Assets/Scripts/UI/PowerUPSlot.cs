using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PowerUPSlot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] GameObject descriptionPanel;

    [SerializeField] string playerPrefCode;

    [SerializeField] int code;

    [SerializeField] Image iconImage;
    [SerializeField] TextMeshProUGUI SkillName;
    [SerializeField] TextMeshProUGUI Description;
    [SerializeField] TextMeshProUGUI Cost;

    [SerializeField] Image[] levelImages;

    PermanentSkillSO permanentSkillSO;

    string playerPrefLevelCode;

    void Start() 
    {
        playerPrefLevelCode = playerPrefCode + "Level";
        GetComponent<Button>().onClick.AddListener(OnClickEvent);
        permanentSkillSO = SkillSOKeeper.Instance.GetPermanentSkillSOByCode(code, PlayerPrefs.GetInt(playerPrefLevelCode));
        SetValues();
    }

    public void SetValues()
    {
        iconImage.sprite = permanentSkillSO.SkillIcon;
        SkillName.text = permanentSkillSO.SkillName;

        for(int i = 0; i < permanentSkillSO.MaxLevel; i++)
        {
            levelImages[i].gameObject.SetActive(true);
            if(i < permanentSkillSO.Level)
                levelImages[i].color = new(0, 0.64f, 0, 1);
        }

        if(permanentSkillSO.Full)
        {
            SetDescriptionPanel(false);
            return;
        }
        PermanentSkillSO nextSkillSO = SkillSOKeeper.Instance.GetPermanentSkillSOByCode(code, PlayerPrefs.GetInt(playerPrefLevelCode) + 1);;
        Description.text = nextSkillSO.Description;
        Cost.text = nextSkillSO.Cost.ToString();
    }

    void OnClickEvent()
    {
        if(permanentSkillSO.Full) return;

        if(PlayerPrefs.GetInt(ConstStrings.PERMANENT_MONEY_KEY) >= 
        SkillSOKeeper.Instance.GetPermanentSkillSOByCode(code, PlayerPrefs.GetInt(playerPrefLevelCode) + 1).Cost)
        {
            permanentSkillSO = SkillSOKeeper.Instance.GetPermanentSkillSOByCode(code, PlayerPrefs.GetInt(playerPrefLevelCode) + 1);
            PlayerPrefs.SetInt(ConstStrings.PERMANENT_MONEY_KEY, PlayerPrefs.GetInt(ConstStrings.PERMANENT_MONEY_KEY) - permanentSkillSO.Cost);
            PlayerPrefs.SetInt(playerPrefLevelCode, permanentSkillSO.Level);
            MainMenuManager.Instance.SetPermanentMoneyText();
        }

        SetValues();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if(permanentSkillSO.Full) return;
        SetDescriptionPanel(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        SetDescriptionPanel(false);
    }

    void SetDescriptionPanel(bool value)
    {
        descriptionPanel.SetActive(value);
    }

}
