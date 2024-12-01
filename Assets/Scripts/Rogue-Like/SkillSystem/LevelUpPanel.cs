using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class LevelUpPanel : MonoBehaviour
{
    [SerializeField] Color evolveColor;
    [SerializeField] Color normalColor;

    [SerializeField] GameObject levelUpPanelObject;
    [SerializeField] ParticleSystem levelUpVFX;

    [SerializeField] UISkillButton[] UISkillButtons;

    public void SetRandomUISkillButtons(bool isBoss)
    {
        Vector2 randomRange = new(0,10);

        //  if(Random.Range(0,2) % 2 == 0 || isBoss)
        //  {
        //      randomRange = new(10,20);
        //  }

        if(isBoss)
        {
            randomRange = new(10,20);
        }

        for(int i = 0; i < UISkillButtons.Length; i++)
        {
            if(i >= InventorySystem.Instance.HowManySlowAvailableByCode((int)Random.Range(randomRange.x, randomRange.y)))
            {
                UISkillButtons[i].ResetUIButton();
                if(InventorySystem.Instance.HowManySlowAvailableByCode((int)Random.Range(randomRange.x, randomRange.y)) == 0)
                {
                    UISkillButtons[i].SetValues(SkillSOKeeper.Instance.GetSkillFulledSO(i), normalColor);
                }
                continue;
            }

            while(true)
            {
                SkillSO choosedSkillSO;
                SkillSO evolveableSkillSO = EvolveableSkillSO();
                Color useColor;

                if(evolveableSkillSO != null && isBoss && HasDifferent(UISkillButtons[i], evolveableSkillSO.code))
                {
                    choosedSkillSO = evolveableSkillSO;
                    useColor = evolveColor;
                }
                else
                {
                    while(true)
                    {
                        int code = (int)Random.Range(randomRange.x, randomRange.y);
                        if(!InventorySystem.Instance.IsSkillSOFullLevel(code))
                        {
                            choosedSkillSO = SkillSOKeeper.Instance.GetSkillSOByCode(code, InventorySystem.Instance.GetSkillSO(code).Level);
                            useColor = normalColor;
                            break;
                        }
                    }
                }

                UISkillButtons[i].SetValues(choosedSkillSO, useColor);

                if(HasDifferent(UISkillButtons[i], choosedSkillSO.code))
                {
                    if(isBoss && choosedSkillSO.code >= 20)
                        break;
                    else if((InventorySystem.Instance.GetHowManySkillHaveByCode(choosedSkillSO.code) == 5 && InventorySystem.Instance.GetableSkillSOCode(choosedSkillSO.code)) || 
                    ((InventorySystem.Instance.GetHowManySkillHaveByCode(choosedSkillSO.code) < 5) && !InventorySystem.Instance.GetableSkillSOCode(choosedSkillSO.code)))
                        break;
                }
            }
        }

        SetPanel(true);
    }

    SkillSO EvolveableSkillSO()
    {
        List<SkillSO> canEvolveSkills = new();
        for (int i = 10; i < 20; i++)
        {
            if(InventorySystem.Instance.GetSkillSO(i).isEvolved) continue;

            if(HaveEvolveSkill(InventorySystem.Instance.GetSkillSO(i).NeededPasifeSkillSO) && InventorySystem.Instance.GetSkillSO(i).Level == 5)
            {
                canEvolveSkills.Add(SkillSOKeeper.Instance.GetEvolvedSkillSOByCode(i-10)); 
            }
        }

        if(canEvolveSkills.Count == 0)
        {
            return null;
        }
        else
        {
            return canEvolveSkills[Random.Range(0, canEvolveSkills.Count)];
        }
    }

    bool HaveEvolveSkill(SkillSO _skillSO)
    {
        for (int i = 0; i < 10; i++)
        {
            if(InventorySystem.Instance.GetSkillSO(i) == _skillSO)
            {
                return true;
            }
        }

        return false;
    }

    void SetPanel(bool value)
    {
        // LevelUp SFX

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

    bool HasDifferent(UISkillButton button, int code)
    {
        foreach(var item in UISkillButtons)
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
            item.ResetUIButton();
        }

        SetPanel(false);
    }

}
