using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstEnemyDied : MonoBehaviour
{

    void Start()
    {
        GlobalUnitTargets.Instance.OnAnEnemyDead += OnAnEnemyDead;
    }

    void OnAnEnemyDead(object sender, GlobalUnitTargets.OnAnUnitDeadEventArgs e)
    {
        if(WriteText.Instance.GetMGanTextSO.name == 36.ToString())
        {
            PlayableDirectorManager.Instance.PlayNextTimeLine();
        }
    }

    void OnDestroy() 
    {
        GlobalUnitTargets.Instance.OnAnEnemyDead -= OnAnEnemyDead;
    }

}
