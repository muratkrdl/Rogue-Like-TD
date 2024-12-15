using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;

public class PlayableDirectorManager : MonoBehaviour
{
    public static PlayableDirectorManager Instance;

    [SerializeField] PlayableDirector playableDirectorNone;
    [SerializeField] PlayableDirector playableDirectorLoop;

    PlayableAsset SetNextPlayableAsset
    {
        set
        {
            playableDirectorNone.playableAsset = value;
            playableDirectorLoop.playableAsset = value;
        }
    }

    void Awake() 
    {
        Instance = this;
    }

    void Start() 
    {
        playableDirectorNone.played += PlayableDirector_Played;
        playableDirectorLoop.played += PlayableDirector_Played;
    }

    public void PlayNextTimeLine()
    {
        SetNextPlayableAsset = WriteText.Instance.GetMGanTextSO.playTimeLine;
        if(WriteText.Instance.GetMGanTextSO.loop)
        {
            playableDirectorLoop.Play();
        }
        else
        {
            playableDirectorNone.Play();
        }
        WriteText.Instance.StartTypewriter();
    }

    void PlayableDirector_Played(PlayableDirector director)
    {
        GameStateManager.Instance.PauseGame();
    }

    void OnDestroy() 
    {
        playableDirectorNone.played -= PlayableDirector_Played;
        playableDirectorLoop.played -= PlayableDirector_Played;
    }

}
