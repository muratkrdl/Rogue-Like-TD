using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InMainTower : MonoBehaviour
{
    bool canPlayNextTimeLine = false;

    void Start() 
    {
        MainTowerManager.Instance.OnInteractWithMainTower += OnInteractWithMainTower;
    }

    void OnInteractWithMainTower(object sender, MainTowerManager.OnInteractWithMainTowerEventArgs e)
    {
        if(WriteText.Instance.GetMGanTextSO.name == 13.ToString() && !canPlayNextTimeLine)
        {
            canPlayNextTimeLine = true;
            PlayableDirectorManager.Instance.PlayNextTimeLine();
        }
    }

    void OnDestroy() 
    {
        MainTowerManager.Instance.OnInteractWithMainTower -= OnInteractWithMainTower;
    }

}
