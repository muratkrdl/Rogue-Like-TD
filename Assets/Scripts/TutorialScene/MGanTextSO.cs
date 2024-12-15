using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

[CreateAssetMenu(menuName = "Create MGanText", fileName = "new MGanText")]
public class MGanTextSO : ScriptableObject
{
    public bool loop;
    public bool play;
    public bool canInteract;
    public string text;
    public string buttonName;
    public MGanTextSO nextText;
    public PlayableAsset playTimeLine;
}
