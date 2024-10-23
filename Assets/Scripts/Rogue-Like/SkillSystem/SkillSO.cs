using UnityEngine;

[CreateAssetMenu(menuName = "SkillSO", fileName = "NewSkillSO")]
public class SkillSO : ScriptableObject
{
    public bool IsActive;
    public Sprite SkillIcon;
    public string SkillName;
    public int Level;
    public int Value;
    public float CooldDown;
    public int ProjectileCount;
    public float Size;
    public string Description;
}
