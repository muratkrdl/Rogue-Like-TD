using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UISkillButton : MonoBehaviour
{
    [SerializeField] Image skillIcon;
    [SerializeField] TextMeshProUGUI skillName;
    [SerializeField] TextMeshProUGUI skillLevel;
    [SerializeField] TextMeshProUGUI Description;

    int code = -1;

    public int Code
    {
        get => code;
        set => code = value;
    }

    public void SetValues(SkillSO skillSO, int code)
    {
        skillIcon.sprite = skillSO.SkillIcon;
        skillName.text = skillSO.SkillName;
        Description.text = skillSO.Description;
        if(skillSO.Level == 1)
            skillLevel.text = "New!";
        else
            skillLevel.text = "lv:" + skillSO.Level.ToString();
        this.code = code; 
    }

    public void OnClick_SkillUpgrade()
    {
        InventorySystem.Instance.LevelUpSkill(code);
    }

}
