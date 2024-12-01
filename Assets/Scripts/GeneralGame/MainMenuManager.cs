using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    public static MainMenuManager Instance;

    [SerializeField] TextMeshProUGUI permanentMoneyText;

    [SerializeField] Menu[] menus;

    void Awake() 
    {
        Instance = this;
    }

    void Start()
    {
        PlayerPrefs.SetInt(ConstStrings.PERMANENT_MONEY, 2340);
        SetPermanentMoneyText();
    }

    public void SetPermanentMoneyText()
    {
        permanentMoneyText.text = PlayerPrefs.GetInt(ConstStrings.PERMANENT_MONEY).ToString();
    }

    public void OpenMenu(string str)
    {
        foreach(Menu menu in menus)
        {
            if(str.Equals(menu.GetMenuName))
                menu.Open();
            else
                menu.Close();
        }

        GameStateManager.Instance.PauseGame();
    }

    public void CloseAllMenu()
    {
        foreach(Menu menu in menus)
        {
            menu.Close();
        }
        GameStateManager.Instance.ResumeGame();
    }

}
