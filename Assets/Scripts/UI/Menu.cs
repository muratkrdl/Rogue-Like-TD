using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] string menuName;
    bool isOpen;

    public string GetMenuName
    {
        get => menuName;
    }
    public bool GetIsOpen
    {
        get => isOpen;
    }

    public void Open()
    {
        isOpen = true;
        gameObject.SetActive(true);
    }

    public void Close()
    {
        isOpen = false;
        gameObject.SetActive(false);
    }

}
