using System;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUIPanel : MonoBehaviour
{
    public static InventoryUIPanel Instance;

    public EventHandler<OnSetNewActiveSkillIconEventArgs> OnSetNewActiveSkillIcon;
    public class OnSetNewActiveSkillIconEventArgs : EventArgs
    {
        public int _code;
        public Image _slider;
    }

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
        OnSetNewActiveSkillIcon?.Invoke(this, new() { _code = code, _slider = activeIcons[InventorySystem.Instance.GetHowManyActiveHave].GetSlider } );
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
