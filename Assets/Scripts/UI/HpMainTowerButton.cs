using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class HpMainTowerButton : MonoBehaviour
{
    [SerializeField] int hpMainTowerButtonCD;

    [SerializeField] TextMeshProUGUI hpMainTowerButtonCDText;
    [SerializeField] GameObject hpMainTowerButtonBG;

    CancellationTokenSource cts = new();

    bool canUseSkill = true;

    void Start() 
    {
        GetComponent<Button>().onClick.AddListener(OnClick_Event);
    }

    void OnClick_Event()
    {
        if(!canUseSkill) return;
        GlobalUnitTargets.Instance.GetMainTower().GetComponent<TowerHealth>().SetFullTowerHP();
        SoundManager.Instance.PlaySound2DVolume(ConstStrings.MAINTOWERHP, .5f);
        CDPlayerButton().Forget();
    }

    async UniTaskVoid CDPlayerButton()
    {
        canUseSkill = false;
        int t = hpMainTowerButtonCD;
        hpMainTowerButtonBG.SetActive(true);
        hpMainTowerButtonCDText.gameObject.SetActive(true);
        hpMainTowerButtonCDText.text = t.ToString();
        while(true)
        {
            await UniTask.WaitUntil(() => !GameStateManager.Instance.GetIsGamePaused, cancellationToken: cts.Token);
            await UniTask.Delay(TimeSpan.FromSeconds(1));
            t--;
            hpMainTowerButtonCDText.text = t.ToString();
            if(t <= 0)
            {
                hpMainTowerButtonBG.SetActive(false);
                hpMainTowerButtonCDText.gameObject.SetActive(false);
                canUseSkill = true;
                break;
            }
        }
    }

    void OnDestroy() 
    {
        cts.Cancel();    
    }

}
