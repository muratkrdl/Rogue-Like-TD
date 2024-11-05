using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseTowerPanelKeeper : MonoBehaviour
{
    [SerializeField] GameObject[] baseTowerPanels;

    public void OpenCanvas(GameObject openCanvas)
    {
        foreach (var item in baseTowerPanels)
        {
            if(item == openCanvas)
            {
                item.SetActive(true);
            }
            else
            {
                item.SetActive(false);
            }
        }
    }

    public void CloseAllCanvas()
    {
        foreach (var item in baseTowerPanels)
        {
            item.gameObject.SetActive(false);
        }
    }

}
