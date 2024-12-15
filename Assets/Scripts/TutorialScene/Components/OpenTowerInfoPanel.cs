using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenTowerInfoPanel : MonoBehaviour
{
    [SerializeField] GameObject mustbeOpenInfo;

    bool canPlayNextTimeLine = false;

    void Update() 
    {
        if(mustbeOpenInfo.activeSelf && WriteText.Instance.GetMGanTextSO.name == 15.ToString() && !canPlayNextTimeLine)
        {
            canPlayNextTimeLine = true;
            PlayableDirectorManager.Instance.PlayNextTimeLine();
        }
        if(canPlayNextTimeLine && int.Parse(WriteText.Instance.GetMGanTextSO.name) <= 21 && !mustbeOpenInfo.activeSelf)
        {
            mustbeOpenInfo.SetActive(true);
        }
    }

}
