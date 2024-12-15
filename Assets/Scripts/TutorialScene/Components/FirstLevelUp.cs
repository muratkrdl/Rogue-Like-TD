using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstLevelUp : MonoBehaviour
{
    void Start()
    {
        WriteText.Instance.OnClickOkey += OnClickOkey;
        ExperienceSystem.Instance.OnGetExperience += OnGetExperience;
    }

    void OnGetExperience(object sender, ExperienceSystem.OnGetExperienceEventArgs e)
    {
        if(WriteText.Instance.GetMGanTextSO.name == 40.ToString())
        {
            PlayableDirectorManager.Instance.PlayNextTimeLine();
            Invoke(nameof(Delay), .01f);
        }
    }

    void Delay()
    {
        LevelUpPanel.Instance.SetRandomUISkillButtons(true);
    }

    void OnClickOkey(object sender, EventArgs e)
    {
        if(WriteText.Instance.GetMGanTextSO.name == 47.ToString())
        {
            EnemySpawner.Instance.SetCanSpawnPhysical = true;
        }
    }

    void OnDestroy() 
    {
        WriteText.Instance.OnClickOkey -= OnClickOkey;
        ExperienceSystem.Instance.OnGetExperience -= OnGetExperience;
    }

}
