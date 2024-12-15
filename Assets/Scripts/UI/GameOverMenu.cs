using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverMenu : MonoBehaviour
{
    public static GameOverMenu Instance;

    [SerializeField] Animator[] otherMenus;

    [SerializeField] TextMeshProUGUI gainedMoneyText;

    [SerializeField] Button quitButton;

    bool isGameOver;

    public bool IsGameOver
    {
        get => isGameOver;
        set => isGameOver = value;
    }

    void Awake() 
    {
        Instance = this;    
    }

    void SetGainedMoneyText(int value)
    {
        gainedMoneyText.text = value.ToString();
    }

    public void GameOver()
    {
        foreach(var item in otherMenus)
        {
            item.SetTrigger(ConstStrings.CLOSE);
        }

        isGameOver = true;
        SetGainedMoneyText(Bank.Instance.GetGainedPermanentMoney);
        Invoke(nameof(InvokeMenuAnim), 3f);
    }

    void InvokeMenuAnim()
    {
        GetComponent<Animator>().SetTrigger(ConstStrings.ANIM);
    }

    public void OnClick_Quit()
    {
        quitButton.interactable = false;
        FadeImageController.Instance.SetFadeImage(true);

        int gainedMoney = int.Parse(gainedMoneyText.text);
        PlayerPrefs.SetInt(ConstStrings.PERMANENT_MONEY_KEY, PlayerPrefs.GetInt(ConstStrings.PERMANENT_MONEY_KEY) + gainedMoney);

        Invoke(nameof(InvokeForSceneChange), 1.25f);
    }

    public void EndTutorial(int value)
    {
        isGameOver = true;
        GameStateManager.Instance.PauseGame();
        transform.GetChild(0).gameObject.SetActive(false);
        GetComponent<Animator>().SetTrigger(ConstStrings.ANIM);
        gainedMoneyText.text = value.ToString();
        FinishTutorial.Instance.SetEarnPD();
        Invoke(nameof(InvokeMenuAnim), 1f);
    }

    void InvokeForSceneChange()
    {
        SceneManager.LoadScene(0);
    }

}
