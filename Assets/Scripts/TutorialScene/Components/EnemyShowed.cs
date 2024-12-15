using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShowed : MonoBehaviour
{
    public void EnemyShowedHimself()
    {
        Invoke(nameof(InvokeFunc), 3.5f);
    }

    void InvokeFunc()
    {
        if(WriteText.Instance.GetMGanTextSO.name == 32.ToString())
        {
            PlayableDirectorManager.Instance.PlayNextTimeLine();
        }
    }

}
