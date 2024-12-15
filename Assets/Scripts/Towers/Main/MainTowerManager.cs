using System;
using Cinemachine;
using UnityEngine;

public enum MainTowerInOutStates
{
    none,
    inTower,
    outTower
}

public class MainTowerManager : MonoBehaviour
{
    public static MainTowerManager Instance;

    public EventHandler<OnInteractWithMainTowerEventArgs> OnInteractWithMainTower;
    public class OnInteractWithMainTowerEventArgs : EventArgs
    {
        public MainTowerInOutStates state;
    }

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

    void MainTowerManager_OnInteractWithMainTower(object sender, OnInteractWithMainTowerEventArgs e)
    {
        if(Mathf.Abs(Vector2.Distance(transform.position, mainChar.position)) > closeDistance && !mainChar.GetComponent<PlayerHealth>().IsDead) return;

        bool gettingIn = e.state switch
        {
            MainTowerInOutStates.outTower => true,
            MainTowerInOutStates.inTower => false,
            _ => !isIn
        };

        if(gettingIn)
        {
            cinemachineVirtualCamera.GetComponent<Animator>().SetTrigger("In");
            cinemachineVirtualCamera.Follow = mainChar;
            isIn = true;
        }
        else
        {
            cinemachineVirtualCamera.GetComponent<Animator>().SetTrigger("Out");
            cinemachineVirtualCamera.Follow = transform;
            isIn = false;
        }
        LMouseClick.Instance.CloseEverything(false);
        isIn = gettingIn;
        mainChar.gameObject.SetActive(isIn);
    }

    void OnDestroy() 
    {
        OnInteractWithMainTower -= MainTowerManager_OnInteractWithMainTower;
    }

}
