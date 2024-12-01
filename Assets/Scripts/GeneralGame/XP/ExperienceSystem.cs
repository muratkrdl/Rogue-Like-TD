using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class ExperienceSystem : MonoBehaviour
{
    public static ExperienceSystem Instance;

    public EventHandler<OnGetExperienceEventArgs> OnGetExperience;
    public class OnGetExperienceEventArgs : EventArgs
    {
        public string name;
    }

    [SerializeField] LevelUpPanel levelUpPanel;
    [SerializeField] ExperiencePanel experiencePanel;

    [SerializeField] int[] gemEarnXPAmount;
    [SerializeField] int[] needExperienceToLevelUp;

    int currentExperience = 0;
    int currentLevel = 1;

    void Awake() 
    {
        Instance = this;
    }

    void Start() 
    {
        OnGetExperience += ExperienceSystem_OnGetExperience;
        experiencePanel.SetExperienceSlider(currentExperience, needExperienceToLevelUp[currentLevel-1], currentLevel);
    }

    void ExperienceSystem_OnGetExperience(object sender, OnGetExperienceEventArgs e)
    {
        int increaseAmount = e.name switch
        {
            "ExperienceObj1(Clone)" => gemEarnXPAmount[0],
            "ExperienceObj2(Clone)" => gemEarnXPAmount[1],
            _ => gemEarnXPAmount[2],
        };

        increaseAmount += PermanentSkillSystem.Instance.GetPermanentSkillSO(2).Value;

        IncreaseExperience(increaseAmount);
    }

    void IncreaseExperience(int increaseAmount)
    {
        currentExperience += increaseAmount;
        if(currentExperience >= needExperienceToLevelUp[currentLevel-1])
        {
            SetRandomUISkillButtons(false);
            currentLevel++;
            currentExperience -= needExperienceToLevelUp[currentLevel-2];
        }
        experiencePanel.SetExperienceSlider(currentExperience, needExperienceToLevelUp[currentLevel-1], currentLevel);
    }

    public void SetRandomUISkillButtons(bool isBoss)
    {
        levelUpPanel.SetRandomUISkillButtons(isBoss);
    }

    void OnDestroy() 
    {
        OnGetExperience -= ExperienceSystem_OnGetExperience;
    }

}
