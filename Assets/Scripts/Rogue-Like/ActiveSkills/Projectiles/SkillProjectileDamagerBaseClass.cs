using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public abstract class SkillProjectileDamagerBaseClass : MonoBehaviour
{
    [SerializeField] Transform originTransform;

    [SerializeField] int skillCode;

    [SerializeField] int damageColorCode;

    List<Collider2D> unitHealths = new();

    float damage;

    public float Damage
    {
        get => damage;
        set => damage = value;
    }

    public int GetSkillCode
    {
        get => skillCode;
    }

    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        if(other.transform.CompareTag(TagManager.ENEMY) && !IsContain(other) && !GameStateManager.Instance.GetIsGamePaused)
        {
            other.transform.GetComponent<UnitHealth>().TakeDamageFromPlayer(damage, InventorySystem.Instance.GetSkillSO(skillCode).DamageType, damageColorCode);
            other.transform.GetComponent<Rigidbody2D>().AddForce((other.transform.position - originTransform.position).normalized * InventorySystem.Instance.GetSkillSO(skillCode).KnockbackAmount);
            unitHealths.Add(other);
            OnDamageFunc();

            if(InventorySystem.Instance.GetSkillSO(GetSkillCode).isEvolved)
                EvolveFunc(other);
        }
    }

    protected virtual void EvolveFunc(Collider2D other) { /* */ }

    protected virtual void OnDamageFunc() { /* */ }

    public void SetDamageOnSpawn()
    {
        damage = InventorySystem.Instance.GetSkillSO(skillCode).Value;
    }

    bool IsContain(Collider2D other)
    {
        if(unitHealths.Contains(other))
            return true;

        return false;
    }

    public void ClearList()
    {
        unitHealths.Clear();
    }
}
