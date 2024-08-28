using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseTowerPanelKeeper : MonoBehaviour
{
    [SerializeField] Image[] baseTowerPanels;

    public void OpenCanvas(Image openCanvas)
    {
        foreach (var item in baseTowerPanels)
        {
            if(item == openCanvas)
            {
                item.gameObject.SetActive(true);
            }
            else
            {
                item.gameObject.SetActive(false);
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
