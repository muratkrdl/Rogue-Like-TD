using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUIPanel : MonoBehaviour
{
    public static InventoryUIPanel Instance;

    [SerializeField] Image[] pasifeIcons;
    [SerializeField] Image[] activeIcons;

    void Awake() 
    {
        Instance = this;    
    }

    public void SetNewPasifeSkillIcon(int code)
    {
        pasifeIcons[InventorySystem.Instance.GetHowManyPasifeHave].sprite = SkillSOKeeper.Instance.GetSkillSOByCode(code, 0).SkillIcon;
    }

    public void SetNewActiveSkillIcon(int code)
    {
        activeIcons[InventorySystem.Instance.GetHowManyActiveHave].sprite = SkillSOKeeper.Instance.GetSkillSOByCode(code, 0).SkillIcon;
    }

}
