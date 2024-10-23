using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUpPanel : MonoBehaviour
{
    [SerializeField] GameObject levelUpPanelObject;
    [SerializeField] ParticleSystem levelUpVFX;

    [SerializeField] UISkillButton[] UISkillButtons;

    public void SetRandomUISkillButtons()
    {
        Vector2 randomRange = new(0,10);

        if(Random.Range(0,2) % 2 == 0)
        {
            randomRange = new(10,20);
        }

        foreach (var item in UISkillButtons)
        {
            while(true)
            {
                int code = (int)Random.Range(randomRange.x, randomRange.y);
                item.SetValues(SkillSOKeeper.Instance.GetSkillSOByCode(code, InventorySystem.Instance.GetSkillSO(code).Level), code);
                if(InventorySystem.Instance.GetHowManySkillHaveByCode(code) == 5)
                {
                    if(HasDifferent(item, code) && InventorySystem.Instance.GetableSkillSOCode(code))
                    {
                        break;
                    }
                }
                else
                {
                    if(HasDifferent(item, code))
                    {
                        break;
                    }
                }
            }
        }

        SetPanel(true);
    }

    void SetPanel(bool value)
    {
        // LEvelUp SFX

        levelUpPanelObject.SetActive(value);
        if(value)
        {
            levelUpVFX.Play();
            GameStateManager.Instance.PauseGame();
        }
        else
        {
            levelUpVFX.Stop();
            GameStateManager.Instance.ResumeGame();
        }

        // Pause
    }

    public bool HasDifferent(UISkillButton button, int code)
    {
        foreach (var item in UISkillButtons)
        {
            if(item == button) continue;

            if(code == item.Code)
                return false;
        }

        return true;
    }

    public void OnClick_Button()
    {
        foreach (var item in UISkillButtons)
        {
            item.Code = -1;
        }

        SetPanel(false);
    }

}
