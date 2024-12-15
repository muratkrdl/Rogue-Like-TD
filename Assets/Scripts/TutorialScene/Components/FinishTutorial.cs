using System;
using UnityEngine;

public class FinishTutorial : MonoBehaviour
{
    public static FinishTutorial Instance;

    [SerializeField] GameObject startButton;

    void Awake() 
    {
        Instance = this;    
    }

    void Start()
    {
        WriteText.Instance.OnClickOkey += OnClickOkey;
    }

    void OnClickOkey(object sender, EventArgs e)
    {
        if(WriteText.Instance.GetMGanTextSO.name == 60.ToString())
        {
            // tutorial end earn 50 PD
            int returnMoney = 0;
            if(PlayerPrefs.GetInt(ConstStrings.HAS_GOT_PD_KEY) == 0) returnMoney = 50;
            GameOverMenu.Instance.EndTutorial(returnMoney);
        }

        if(WriteText.Instance.GetMGanTextSO.name == 31.ToString())
        {
            Invoke(nameof(DelayFunc), .03f);
        }
    }

    void DelayFunc()
    {
        startButton.SetActive(true);
    }

    public void SetEarnPD()
    {
        PlayerPrefs.SetInt(ConstStrings.HAS_GOT_PD_KEY, 1);
    }

    void OnDestroy() 
    {
        WriteText.Instance.OnClickOkey -= OnClickOkey;
    }

}
