using UnityEngine;

[CreateAssetMenu(menuName = "PermanentSkillSO", fileName = "PermanentNewSkillSO")]
public class PermanentSkillSO : ScriptableObject
{
    public bool Full;
    public Sprite SkillIcon;
    public string SkillName;
    public int Level;
    public int MaxLevel;
    public int Value;
    public int Cost;
    public string Description;
}
