using System;
using UnityEngine;

public class InventorySystem : MonoBehaviour
{
    public static InventorySystem Instance;

    public EventHandler<OnDamageWithActiveSkillsEventArgs> OnDamageWithActiveSkills;
    public class OnDamageWithActiveSkillsEventArgs : EventArgs
    {
        public int damage;
    }

    public EventHandler<OnSkillUpdateEventArgs> OnPasifeUpdate;
    public EventHandler<OnSkillUpdateEventArgs> OnNewSkillGain;
    public class OnSkillUpdateEventArgs : EventArgs
    {
        public int Code;
    }

    [SerializeField] SkillSO[] skillSOs;

    int howManyPasifeHave = 0;
    int howManyActiveHave = 0;

    public int GetHowManyPasifeHave
    {
        get => howManyPasifeHave;
    }
    public int GetHowManyActiveHave
    {
        get => howManyActiveHave;
    }

    void Awake() 
    {
        Instance = this;
    }

    public void LevelUpSkill(int code)
    {
        skillSOs[code] = SkillSOKeeper.Instance.GetSkillSOByCode(code, GetSkillSO(code).Level);
        if(GetSkillSO(code).Level == 1)
        {
            if(code < 10)
            {
                InventoryUIPanel.Instance.SetNewPasifeSkillIcon(code);
                howManyPasifeHave++;
            }
            else
            {
                InventoryUIPanel.Instance.SetNewActiveSkillIcon(code);
                howManyActiveHave++;

                OnNewSkillGain?.Invoke(this, new() { Code = code } );
            }
        }

        OnPasifeUpdate?.Invoke(this, new() { Code = code } );
    }

    public int GetHowManySkillHaveByCode(int code)
    {
        if(code < 10)
            return howManyPasifeHave;
        else
            return howManyActiveHave;
    }

    public bool GetableSkillSOCode(int code)
    {
        if(GetSkillSO(code).Level == 0)
        {
            return false;
        }

        return true;
    }

    public SkillSO GetSkillSO(int code)
    {
        return skillSOs[code];
    }

}
