using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ActiveSkillBaseClass : MonoBehaviour
{
    [SerializeField] int skillCode;

    bool isEvolved = false;

    public bool canUseSkill = false;

    Vector2 currentScale = Vector2.one;

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
            currentScale = new(InventorySystem.Instance.GetSkillSO(GetSkillCode).Size, InventorySystem.Instance.GetSkillSO(GetSkillCode).Size);
        }
    }

    public float GetSkillCoolDown()
    {
        return InventorySystem.Instance.GetSkillSO(skillCode).CooldDown - InventorySystem.Instance.GetSkillSO(skillCode).CooldDown * InventorySystem.Instance.GetSkillSO(9).Value / 100;
    }

}
