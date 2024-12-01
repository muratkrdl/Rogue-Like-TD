using System;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;

public class InventorySystem : MonoBehaviour
{
    public static InventorySystem Instance;

    public EventHandler<OnDamageWithActiveSkillsEventArgs> OnDamageWithActiveSkills;
    public class OnDamageWithActiveSkillsEventArgs : EventArgs
    {
        public float damage;
    }

    public EventHandler<OnSkillUpdateEventArgs> OnSkillUpdate;
    public EventHandler<OnSkillUpdateEventArgs> OnNewSkillGain;
    public EventHandler<OnSkillUpdateEventArgs> OnSkillEvolved;
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

        OnSkillUpdate?.Invoke(this, new() { Code = code } );
    }

    public void EvolveSkill(int code)
    {
        skillSOs[code-10] = SkillSOKeeper.Instance.GetSkillSOByCode(code, GetSkillSO(code-10).Level);
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

    public int HowManySlowAvailableByCode(int code)
    {
        int a = 0;

        int maxRange = 20;

        if(code < 10)
        {
            maxRange = 10;
        }

        for (int i = maxRange-10; i < maxRange; i++)
        {
            if(GetHowManySkillHaveByCode(code) < 5)
            {
                if(GetSkillSO(i).Level == 0)
                {
                    a++;
                }
            }
            else
            {
                if(GetSkillSO(i).Level != 0 && GetSkillSO(i).Level != 5)
                {
                    a++;
                }
            }
        }
    
        return a;
    }

    public bool IsSkillSOFullLevel(int code)
    {
        if(GetSkillSO(code).Level != 5)
        {
            return false;
        }

        return true;
    }

    public bool EvolveableSkillSO(int code)
    {
        if(GetSkillSO(code).isEvolved)
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
