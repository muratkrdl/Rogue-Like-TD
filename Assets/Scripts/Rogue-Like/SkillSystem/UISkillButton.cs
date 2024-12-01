using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UISkillButton : MonoBehaviour
{
    [SerializeField] int initialCode;

    [SerializeField] Image panelImage;

    [SerializeField] Image skillIcon;
    [SerializeField] TextMeshProUGUI skillName;
    [SerializeField] TextMeshProUGUI skillLevel;
    [SerializeField] TextMeshProUGUI description;

    int code = -1;

    public int Code
    {
        get => code;
        set => code = value;
    }

    public void SetValues(SkillSO skillSO, Color color)
    {
        gameObject.SetActive(true);

        skillIcon.sprite = skillSO.SkillIcon;
        skillName.text = skillSO.SkillName;
        description.text = skillSO.Description;

        if(skillSO.Level == 1)
            skillLevel.text = "New!";
        else if(skillSO.code >= 30)
            skillLevel.text = " ";
        else
            skillLevel.text = "lv:" + skillSO.Level.ToString();
        code = skillSO.code;

        panelImage.color = color;
    }

    public void ResetUIButton()
    {
        gameObject.SetActive(false);

        code = initialCode;
    }

    public void OnClick_SkillUpgrade()
    {
        if(code < 20)
        {
            InventorySystem.Instance.LevelUpSkill(code);
        }
        else
        {
            switch (code)
            {
                case < 30:
                    InventoryUIPanel.Instance.SetSkillEvolved(code);
                    InventorySystem.Instance.EvolveSkill(code);
                    InventorySystem.Instance.OnSkillEvolved?.Invoke(this, new() { Code = code } );
                    break;
                case 30:
                    Bank.Instance.OnChangeMoneyAmount?.Invoke(this, new () { amount = 200 } );
                    break;
                case 31:
                    GlobalUnitTargets.Instance.GetPlayerTarget().GetComponent<PlayerHealth>().GainHP(35);
                    break;
                case 32:
                
                    break;
                default:
                    break;
            }
        }
    }

}
