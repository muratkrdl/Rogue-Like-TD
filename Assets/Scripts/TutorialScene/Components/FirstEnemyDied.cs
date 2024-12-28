using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstEnemyDied : MonoBehaviour
{
    [SerializeField] GameObject xpPanel;

    void Start()
    {
        GlobalUnitTargets.Instance.OnAnEnemyDead += OnAnEnemyDead;
    }

    void OnAnEnemyDead(object sender, GlobalUnitTargets.OnAnUnitDeadEventArgs e)
    {
        if(WriteText.Instance.GetMGanTextSO.name == 36.ToString())
        {
            xpPanel.SetActive(true);
            PlayableDirectorManager.Instance.PlayNextTimeLine();
        }
    }

    void OnDestroy() 
    {
        GlobalUnitTargets.Instance.OnAnEnemyDead -= OnAnEnemyDead;
    }

}
