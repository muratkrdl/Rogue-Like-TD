using System;
using Cinemachine;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class MainTowerManager : MonoBehaviour
{
    public static MainTowerManager Instance;

    public EventHandler OnInteractWithMainTower;

    [SerializeField] CinemachineVirtualCamera cinemachineVirtualCamera;

    [SerializeField] Transform mainChar;

    [SerializeField] float closeDistance;

    bool isIn = true;

    public bool GetIsIn
    {
        get => isIn;
    }
    
    void Awake() 
    {
        Instance = this;
    }

    void Start() 
    {
        OnInteractWithMainTower += MainTowerManager_OnInteractWithMainTower;
    }

    void MainTowerManager_OnInteractWithMainTower(object sender, EventArgs e)
    {
        if(Mathf.Abs(Vector2.Distance(transform.position, mainChar.position)) > closeDistance && !mainChar.GetComponent<PlayerHealth>().GetIsDead) return;

        if(!isIn)
        {
            cinemachineVirtualCamera.GetComponent<Animator>().SetTrigger("In");
            cinemachineVirtualCamera.Follow = mainChar;
        }
        else
        {
            cinemachineVirtualCamera.GetComponent<Animator>().SetTrigger("Out");
            cinemachineVirtualCamera.Follow = transform;
        }
        LMouseClick.Instance.CloseEverything(false);
        isIn = !isIn;
        mainChar.gameObject.SetActive(isIn);
    }

    void OnDestroy() 
    {
        OnInteractWithMainTower -= MainTowerManager_OnInteractWithMainTower;
    }

}
