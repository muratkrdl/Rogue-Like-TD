using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SkillProjectileDamagerBaseClass : MonoBehaviour
{
    [SerializeField] Transform originTransform;

    [SerializeField] int skillCode;

    [SerializeField] int damageColorCode;

    List<Collider2D> unitHealths = new();

    public int GetSkillCode
    {
        get => skillCode;
    }

    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        if(other.transform.CompareTag(TagManager.ENEMY) && !IsContain(other) && !GameStateManager.Instance.GetIsGamePaused)
        {
            other.transform.GetComponent<UnitHealth>().TakeDamageFromPlayer(InventorySystem.Instance.GetSkillSO(skillCode).Value, InventorySystem.Instance.GetSkillSO(skillCode).DamageType, damageColorCode);
            other.transform.GetComponent<Rigidbody2D>().AddForce((other.transform.position - originTransform.position).normalized * InventorySystem.Instance.GetSkillSO(skillCode).KnockbackAmount);
            unitHealths.Add(other);

            if(InventorySystem.Instance.GetSkillSO(GetSkillCode).isEvolved)
                EvolveFunc(other);
        }
    }

    protected virtual void EvolveFunc(Collider2D other) { /* */ }

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
