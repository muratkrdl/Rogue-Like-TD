using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialEnemyCounter : MonoBehaviour
{
    int counter = 0;

    void Start()
    {
        GlobalUnitTargets.Instance.OnAnEnemyDead += OnAnEnemyDead;
    }

    void OnAnEnemyDead(object sender, GlobalUnitTargets.OnAnUnitDeadEventArgs e)
    {
        counter++;
        if(counter == 15 && WriteText.Instance.GetMGanTextSO.name == 47.ToString())
        {
            PlayNextTimeLine();
        }
    }

    void PlayNextTimeLine()
    {
        PlayableDirectorManager.Instance.PlayNextTimeLine();
    }

    void OnDestroy() 
    {
        GlobalUnitTargets.Instance.OnAnEnemyDead -= OnAnEnemyDead;
    }
}
