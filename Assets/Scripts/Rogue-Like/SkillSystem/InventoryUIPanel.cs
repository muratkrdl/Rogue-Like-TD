using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUIPanel : MonoBehaviour
{
    public static InventoryUIPanel Instance;

    [SerializeField] Color evolvedPanelColor;

    [SerializeField] SkillSlot[] pasifeIcons;
    [SerializeField] SkillSlot[] activeIcons;

    void Awake() 
    {
        Instance = this;    
    }

    public void SetNewPasifeSkillIcon(int code)
    {
        pasifeIcons[InventorySystem.Instance.GetHowManyPasifeHave].ChangeSkillSprite(SkillSOKeeper.Instance.GetSkillSOByCode(code, 0).SkillIcon);
    }

    public void SetNewActiveSkillIcon(int code)
    {
        activeIcons[InventorySystem.Instance.GetHowManyActiveHave].ChangeSkillSprite(SkillSOKeeper.Instance.GetSkillSOByCode(code, 0).SkillIcon);
    }

    public void SetSkillEvolved(int code)
    {
        SkillSlot changeImage = null;

        foreach(var item in activeIcons)
        {
            if(item.GetSkillSprite() == InventorySystem.Instance.GetSkillSO(code-10).SkillIcon)
            {
                changeImage = item;
                break;
            }
        }
        if(changeImage == null) return;

        changeImage.EvolveSkill(SkillSOKeeper.Instance.GetEvolvedSkillSOByCode(code-20).SkillIcon, evolvedPanelColor);
    }

}
