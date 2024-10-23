using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ActiveSkillBaseClass : MonoBehaviour
{
    [SerializeField] int skillCode;

    public bool canUseSkill = false;

    public bool GetCanUseSkill
    {
        get => canUseSkill;
    }

    public void InventorySystem_OnNewSkillGain(object sender, InventorySystem.OnSkillUpdateEventArgs e)
    {
        if(e.Code == skillCode)
        {
            canUseSkill = true;
        }
    }

    public float GetSkillCoolDown()
    {
        return InventorySystem.Instance.GetSkillSO(skillCode).CooldDown - InventorySystem.Instance.GetSkillSO(skillCode).CooldDown * InventorySystem.Instance.GetSkillSO(9).Value / 100;
    }

}
