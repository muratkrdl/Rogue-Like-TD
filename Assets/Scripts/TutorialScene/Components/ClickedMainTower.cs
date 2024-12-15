using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickedMainTower : MonoBehaviour
{
    bool canPlayNextTimeLine = false;

    void Start() 
    {
        InfoPanel.Instance.OnClickedTowerInfo += OnClickedTowerInfo;
    }

    void OnClickedTowerInfo(object sender, InfoPanel.OnClickedTowerInfoEventArg e)
    {
        if(e.isMainTower && WriteText.Instance.GetMGanTextSO.name == 11.ToString() && !canPlayNextTimeLine)
        {
            canPlayNextTimeLine = true;
            PlayableDirectorManager.Instance.PlayNextTimeLine();
        }
    }

    void OnDestroy() 
    {
        InfoPanel.Instance.OnClickedTowerInfo -= OnClickedTowerInfo;
    }

}
