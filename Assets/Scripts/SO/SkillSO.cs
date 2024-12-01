using UnityEngine;

[CreateAssetMenu(menuName = "SkillSO", fileName = "NewSkillSO")]
public class SkillSO : ScriptableObject
{
    public int code;

    public bool isEvolved;

    public Sprite SkillIcon;
    public string SkillName;
    public int Level;
    public int Value;
    public float CooldDown;
    public int ProjectileCount;
    public float Size;
    public float KnockbackAmount;
    public string Description;

    public DamageType DamageType;

    public SkillSO NeededPasifeSkillSO;
}
