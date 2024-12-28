using UnityEngine;

public class AllTowerInfos : MonoBehaviour
{
    public static AllTowerInfos Instance;

    [SerializeField] TowerInfoSo[] arhcerTowerInfos;
    [SerializeField] TowerInfoSo[] mageTowerInfos;
    [SerializeField] TowerInfoSo[] guardianTowerInfos;
    [SerializeField] TowerInfoSo[] catapultTowerInfos;

    [SerializeField] TowerInfoSo[] evolvedArhcerTowerInfos1;
    [SerializeField] TowerInfoSo[] evolvedArhcerTowerInfos2;
    [SerializeField] TowerInfoSo[] evolvedMageTowerInfos1;
    [SerializeField] TowerInfoSo[] evolvedMageTowerInfos2;
    [SerializeField] TowerInfoSo[] evolvedGuardianTowerInfos1;
    [SerializeField] TowerInfoSo[] evolvedGuardianTowerInfos2;
    [SerializeField] TowerInfoSo[] evolvedCatapultTowerInfos1;
    [SerializeField] TowerInfoSo[] evolvedCatapultTowerInfos2;

    void Awake() 
    {
        Instance = this;
    }

    public TowerInfoSo GetTowerInfoSo(int i, int level)
    {
        TowerInfoSo returnTowerInfoSO = i switch
        {
            0 => arhcerTowerInfos[level - 1],
            1 => mageTowerInfos[level - 1],
            2 => guardianTowerInfos[level - 1],
            3 => catapultTowerInfos[level - 1],
            4 => evolvedArhcerTowerInfos1[level - 1],
            5 => evolvedArhcerTowerInfos2[level - 1],
            6 => evolvedMageTowerInfos1[level - 1],
            7 => evolvedMageTowerInfos2[level - 1],
            8 => evolvedGuardianTowerInfos1[level - 1],
            9 => evolvedGuardianTowerInfos2[level - 1],
            10 => evolvedCatapultTowerInfos1[level - 1],
            11 => evolvedCatapultTowerInfos2[level - 1],
            _ => throw new()
        };
        return returnTowerInfoSO;
    }

}
