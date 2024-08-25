using System;
using Cinemachine;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class MainTowerManager : MonoBehaviour
{
    public static MainTowerManager Instance;

    public EventHandler OnInteractWithMainTower;

    [SerializeField] CinemachineVirtualCamera cinemachineVirtualCamera;

    [SerializeField] GameObject mainChar;

    [SerializeField] float closeDistance;

    bool isIn = true;

    public bool GetIsIn
    {
        get
        {
            return isIn;
        }
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
        if(Mathf.Abs(Vector2.Distance(transform.position, mainChar.transform.position)) > closeDistance) return;

        if(!isIn)
        {
            cinemachineVirtualCamera.GetComponent<Animator>().SetTrigger("In");
        }
        else
        {
            cinemachineVirtualCamera.GetComponent<Animator>().SetTrigger("Out");
        }
        LMouseClick.Instance.CloseEverything();
        isIn = !isIn;
        mainChar.SetActive(isIn);
    }

    void OnDestroy() 
    {
        OnInteractWithMainTower -= MainTowerManager_OnInteractWithMainTower;
    }

}
