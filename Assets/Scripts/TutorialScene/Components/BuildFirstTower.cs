using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildFirstTower : MonoBehaviour
{
    [SerializeField] TowerInfoKeeper towerInfoKeeper;

    bool canPlayNextTimeLine = false;

    void Start()
    {
        Bank.Instance.OnChangeMoneyAmount += OnChangeMoneyAmount;
    }

    void OnChangeMoneyAmount(object sender, Bank.BankEventArgs e)
    {
        if(WriteText.Instance.GetMGanTextSO.name == 23.ToString() && !canPlayNextTimeLine)
        {
            PlayableDirectorManager.Instance.PlayNextTimeLine();
            canPlayNextTimeLine = true;
        }

        if(WriteText.Instance.GetMGanTextSO.name == 24.ToString() && canPlayNextTimeLine)
        {
            PlayableDirectorManager.Instance.PlayNextTimeLine();
        }
    }

}
