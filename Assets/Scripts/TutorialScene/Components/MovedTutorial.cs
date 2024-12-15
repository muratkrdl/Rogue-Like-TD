using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovedTutorial : MonoBehaviour
{
    bool canPlayNextTimeLine = false;

    void Update()
    {
        if(GetComponent<GetInputs>().GetMoveInput != Vector2.zero && WriteText.Instance.GetMGanTextSO.name == 6.ToString() && !canPlayNextTimeLine)
        {
            canPlayNextTimeLine = true;
            Invoke(nameof(ForInvoke), 2);
        }
    }

    void ForInvoke()
    {
        GlobalUnitTargets.Instance.GetPlayerTarget().transform.position = new(0,.6f);
        PlayableDirectorManager.Instance.PlayNextTimeLine();
    }
}
