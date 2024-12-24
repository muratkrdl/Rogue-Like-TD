using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class LevelUpPanel : MonoBehaviour
{
    public static LevelUpPanel Instance;

    [SerializeField] Color evolveColor;
    [SerializeField] Color normalColor;

    [SerializeField] GameObject levelUpPanelObject;
    [SerializeField] ParticleSystem levelUpVFX;

    [SerializeField] UISkillButton[] UISkillButtons;

    void Awake() 
    {
        Instance = this;    
    }

    public void SetRandomUISkillButtons(bool isBoss)
    {
        Vector2Int randomRange = new(0, 9);

        if((Random.Range(0,2) % 2) == 0 || isBoss)
        {
            randomRange = new(10,20);
        }

        int hmsa = InventorySystem.Instance.HowManySlotAvailableByCode(Random.Range(randomRange.x, randomRange.y));

        for(int i = 0; i < UISkillButtons.Length; i++)
        {
            UISkillButtons[i].ResetUIButton();
            
            if(i+1 > hmsa)
            {
                if(hmsa == 0)
                {
                    UISkillButtons[i].SetValues(SkillSOKeeper.Instance.GetSkillFulledSO(i), normalColor);
                }
                continue;
            }

            SkillSO choosedSkillSO;
            Color useColor;

            Debug.Log(hmsa);

            while(true)
            {
                SkillSO evolveableSkillSO = EvolveableSkillSO();

                if(isBoss && evolveableSkillSO != null && HasDifferent(UISkillButtons[i], evolveableSkillSO.code))
                {
                    choosedSkillSO = evolveableSkillSO;
                    useColor = evolveColor;
                    UISkillButtons[i].SetValues(choosedSkillSO, useColor);
                    break;
                }
                else
                {
                    while(true)
                    {
                        int code = Random.Range(randomRange.x, randomRange.y +1);
                        if(!InventorySystem.Instance.IsSkillSOFullLevel(code))
                        {
                            choosedSkillSO = SkillSOKeeper.Instance.GetSkillSOByCode(code, InventorySystem.Instance.GetSkillSO(code).Level);
                            useColor = normalColor;
                            if(HasDifferent(UISkillButtons[i], choosedSkillSO.code))
                            {
                                UISkillButtons[i].SetValues(choosedSkillSO, useColor);
                                break;
                            }
                        }
                    }
                }

                if((hmsa <= 5 && InventorySystem.Instance.GetableSkillSOCode(choosedSkillSO.code)) ||
                ((hmsa > 5) && !InventorySystem.Instance.GetableSkillSOCode(choosedSkillSO.code)))
                    break;
            }
        }

        SetPanel(true);
    }

    SkillSO EvolveableSkillSO()
    {
        List<SkillSO> canEvolveSkills = new();
        for(int i = 10; i < 20; i++)
        {
            if(InventorySystem.Instance.GetSkillSO(i).isEvolved) continue;

            if(InventorySystem.Instance.ContainNeededPasifeSkillSO(i) && InventorySystem.Instance.GetSkillSO(i).Level == 5)
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
