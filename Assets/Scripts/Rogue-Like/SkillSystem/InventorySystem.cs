using System;
using System.Linq;
using System.Security.Permissions;
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

    void Start() 
    {
        if(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex == 0) return;
        Invoke(nameof(Invokestart), .1f);
    }

    void Invokestart()
    {
        if(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex != 1 ) return;
        int code = 12;
        while(code == 12)
        {
            code = UnityEngine.Random.Range(10, 20);
        }
        LevelUpSkill(code);
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

    public int HowManySlotAvailableByCode(int code)
    {
        int a = 0;

        int maxRange = 20;

        if(code < 10)
        {
            maxRange = 10;
        }

        for (int i = maxRange-10; i < maxRange; i++)
        {
            if(GetSkillSO(i).isEvolved) continue;

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
        if(code >= 20) return true;
        if(GetSkillSO(code).Level != 5)
        {
            return false;
        }

        return true;
    }

    public bool ContainNeededPasifeSkillSO(int code)
    {
        if(skillSOs.Contains(GetSkillSO(code).NeededPasifeSkillSO))
            return true;
        else
            return false;
    }

    public SkillSO GetSkillSO(int code)
    {
        return skillSOs[code];
    }

}
