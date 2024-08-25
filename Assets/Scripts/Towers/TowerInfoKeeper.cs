using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerInfoKeeper : MonoBehaviour
{
    [SerializeField] TowerInfoSo[] arhcerTowerInfos;
    [SerializeField] TowerInfoSo[] mageTowerInfos;
    [SerializeField] TowerInfoSo[] guardianTowerInfos;
    [SerializeField] TowerInfoSo[] catapultTowerInfos;

    [SerializeField] Image rangeCircle;

    TowerInfoSo currentTowerInfo;

    int currentTowerLevel = 1;
    int currentTowerCode;

    public int CurrentTowerLevel
    {
        get
        {
            return currentTowerLevel;
        }
        set
        {
            currentTowerLevel = value;
        }
    }

    public TowerInfoSo GetCurrentTowerInfo
    {
        get
        {
            return currentTowerInfo;
        }
    }

    public int GetCurrentTowerCode
    {
        get
        {
            return currentTowerCode;
        }
    }
    
    public void SetCurrentTowerInfo(int i, int level)
    {
        currentTowerInfo = GetTowerInfoSo(i, level);
        rangeCircle.transform.localScale = new(currentTowerInfo.Range, currentTowerInfo.Range);
    }

    public TowerInfoSo GetTowerInfoSo(int i, int level)
    {
        TowerInfoSo returnTowerInfoSO = i switch
        {
            0 => arhcerTowerInfos[level -1],
            1 => mageTowerInfos[level -1],
            2 => guardianTowerInfos[level -1],
            _ => catapultTowerInfos[level -1]
        };
        currentTowerCode = i;
        return returnTowerInfoSO;
    }

}
