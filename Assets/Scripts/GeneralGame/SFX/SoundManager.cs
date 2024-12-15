using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;
 
    [SerializeField] SoundLibrary sfxLibrary;
    [SerializeField] AudioSource sfx2DSource;

    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this);
        }
    }

    public void PlaySound2D(string clipName)
    {
        sfx2DSource.PlayOneShot(sfxLibrary.GetClipFromName(clipName));
    }

    public void PlaySound3D(string clipName, Vector3 pos)
    {
        PlaySound3D(sfxLibrary.GetClipFromName(clipName), pos);
    }

    void PlaySound3D(AudioClip clip, Vector3 pos)
    {
        if (clip != null)
        {
            AudioSource.PlayClipAtPoint(clip, pos);
        }
    }
    
}
