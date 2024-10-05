using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LMouseClick : MonoBehaviour
{
    public static LMouseClick Instance;

    [SerializeField] PlaceTowerAnimation[] placeTowersAnimation;
    [SerializeField] InfoPanel InfoPanel;

    [SerializeField] LayerMask layerMask;
    [SerializeField] float range;

    RaycastHit2D hit;

    PlaceTower lastClickedTower;

    public PlaceTower GetLastClickedTower
    {
        get
        {
            return lastClickedTower;
        }
    }

    void Awake() 
    {
        Instance = this;    
    }

    void Update()
    {
        if(Input.GetMouseButtonUp(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            hit = Physics2D.Raycast(ray.origin, ray.direction, range, layerMask);


            if(hit.collider == null)
            {
                CloseEverything(false);
                lastClickedTower = null;
            }
            else
            {
                CloseEverything(true);
                if(hit.collider.TryGetComponent<PlaceTower>(out var clickedTower))
                {
                    clickedTower.OnMouseDownEvent();
                    lastClickedTower = clickedTower;
                }
                else if(hit.collider.TryGetComponent<MainTower>(out var mainTower))
                {
                    mainTower.OnMouseDownEvent();
                }
            }
        }
    }

    public void CloseEverything(bool boolean)
    {
        foreach (var item in placeTowersAnimation)
        {
            item.CloseAnimation();
        }
        if(!boolean)
        {
            InfoPanel.SetInfoPanelAnim(false);
        }
    }

}
