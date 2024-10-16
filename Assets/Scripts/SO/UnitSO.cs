using UnityEngine;

[CreateAssetMenu(fileName = "EnemySO", menuName = "EnemySO")]
public class UnitSO : ScriptableObject
{
    [field: SerializeField] public float AttackRange { get; private set; }
    [field: SerializeField] public int AttackDamage { get; private set; }
    [field: SerializeField] public float TimeBetweenAttack { get; private set; }
    [field: SerializeField] public int MaxHealth { get; private set; }
    [field: SerializeField] public int Armor { get; private set; }
    [field: SerializeField] public int MagicResistance { get; private set; }
}
