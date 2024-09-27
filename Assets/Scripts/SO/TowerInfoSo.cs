using UnityEngine;

[CreateAssetMenu(fileName = "NewTower", menuName = "TowerInfoSO")]
public class TowerInfoSo : ScriptableObject
{
    public int towercode;
    public Sprite towerImageIcon;
    public Sprite towerIcon;
    public string Name;
    public int maxHealth;
    public DamageType damageType;
    public Vector2 BaseDamageRange;
    public float TimeBetweenAttack;
    public Color DamageTypeColor;
    public int projectileCode;
    public int towerCost;
    public int sellPrice;
    public float Range;
    public string Description;
}

public enum DamageType
{
    none,
    physical,
    magic,
    truedamage
}
