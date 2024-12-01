using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ActiveSkillBaseClass : MonoBehaviour
{
    [SerializeField] int skillCode;

    bool isEvolved = false;

    public bool canUseSkill = false;

    Vector2 currentScale = Vector2.one;
    float currentProjectileAmount = 1;

    public int GetSkillCode
    {
        get => skillCode;
    }
    public bool GetIsEvolved
    {
        get => isEvolved;
    }
    public bool GetCanUseSkill
    {
        get => canUseSkill;
    }
    public Vector2 GetCurrentScale
    {
        get => currentScale;
    }
    public float GetCurrentProjectileAmount
    {
        get => currentProjectileAmount;
    }

    public void InventorySystem_OnNewSkillGain(object sender, InventorySystem.OnSkillUpdateEventArgs e)
    {
        if(e.Code == skillCode)
        {
            canUseSkill = true;
        }
    }

    public void InventorySystem_OnSkillUpdate(object sender, InventorySystem.OnSkillUpdateEventArgs e)
    {
        if(e.Code == GetSkillCode)
        {
            currentScale = Vector2.one * InventorySystem.Instance.GetSkillSO(GetSkillCode).Size;
            currentProjectileAmount = InventorySystem.Instance.GetSkillSO(GetSkillCode).ProjectileCount + PermanentSkillSystem.Instance.GetPermanentSkillSO(7).Value;
            OnSkillUpdateFunc();
        }
    }

    protected virtual void OnSkillUpdateFunc() { /* */  }

    public void InventorySystem_OnSkillEvolved(object sender, InventorySystem.OnSkillUpdateEventArgs e) 
    { 
        if(e.Code -10 == GetSkillCode)
        {
            // EVOLVE
            EvolveSkill();
        }
    }

    protected virtual void EvolveSkill() {  /* */ }

    public float GetSkillCoolDown()
    {
        return InventorySystem.Instance.GetSkillSO(skillCode).CooldDown - InventorySystem.Instance.GetSkillSO(skillCode).CooldDown * 
        (InventorySystem.Instance.GetSkillSO(9).Value + PermanentSkillSystem.Instance.GetPermanentSkillSO(0).Value) / 100;
    }

}
