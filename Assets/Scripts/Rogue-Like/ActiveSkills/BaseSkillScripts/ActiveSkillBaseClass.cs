using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public abstract class ActiveSkillBaseClass : MonoBehaviour
{
    [SerializeField] int skillCode;

    CancellationTokenSource cts = new();

    public bool canUseSkill = false;
    Vector2 currentScale = Vector2.one;
    float currentProjectileAmount = 1;

    protected CancellationTokenSource GetCTS
    {
        get => cts;
    }

    protected int GetSkillCode
    {
        get => skillCode;
    }
    protected bool GetCanUseSkill
    {
        get => canUseSkill;
    }
    protected Vector2 GetCurrentScale
    {
        get => currentScale;
    }
    protected float GetCurrentProjectileAmount
    {
        get => currentProjectileAmount;
    }

    protected void OnDestroy_CancelCTS()
    {
        cts.Cancel();
    }
    protected void InventorySystem_OnNewSkillGain(object sender, InventorySystem.OnSkillUpdateEventArgs e)
    {
        if(e.Code == skillCode)
        {
            canUseSkill = true;
        }
    }
    protected void InventorySystem_OnSkillUpdate(object sender, InventorySystem.OnSkillUpdateEventArgs e)
    {
        if(e.Code == GetSkillCode)
        {
            currentScale = Vector2.one * InventorySystem.Instance.GetSkillSO(GetSkillCode).Size;
            currentProjectileAmount = InventorySystem.Instance.GetSkillSO(GetSkillCode).ProjectileCount + PermanentSkillSystem.Instance.GetPermanentSkillSO(7).Value;
            OnSkillUpdateFunc();
        }
    }
    protected void InventorySystem_OnSkillEvolved(object sender, InventorySystem.OnSkillUpdateEventArgs e) 
    { 
        if(e.Code -10 == GetSkillCode)
        {
            // EVOLVE
            EvolveSkill();
        }
    }

    protected virtual void OnSkillUpdateFunc() { /* */  }
    protected virtual void EvolveSkill() {  /* */ }

    protected float GetSkillCoolDown()
    {
        return InventorySystem.Instance.GetSkillSO(skillCode).CooldDown - InventorySystem.Instance.GetSkillSO(skillCode).CooldDown * 
        (InventorySystem.Instance.GetSkillSO(9).Value + PermanentSkillSystem.Instance.GetPermanentSkillSO(0).Value) / 100;
    }

}
