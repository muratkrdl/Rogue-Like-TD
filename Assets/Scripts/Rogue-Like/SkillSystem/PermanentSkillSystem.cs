using UnityEngine;

public class PermanentSkillSystem : MonoBehaviour
{
    public static PermanentSkillSystem Instance;

    PermanentSkillSO[] permanentSkillSOs = new PermanentSkillSO[12];

    void Awake() 
    {
        Instance = this;
    }

    void Start() 
    {
        SetPermanentSkillsSO();
    }

    public void SetPermanentSkillsSO()
    {
        permanentSkillSOs[0] = SkillSOKeeper.Instance.GetPermanentSkillSOByCode(0, PlayerPrefs.GetInt(ConstStrings.PERMANENT_EXTRA_COOLDOWN_LEVEL_KEY));
        permanentSkillSOs[1] = SkillSOKeeper.Instance.GetPermanentSkillSOByCode(1, PlayerPrefs.GetInt(ConstStrings.PERMANENT_EXTRA_DAMAGE_LEVEL_KEY));
        permanentSkillSOs[2] = SkillSOKeeper.Instance.GetPermanentSkillSOByCode(2, PlayerPrefs.GetInt(ConstStrings.PERMANENT_EXTRA_EXPERIENCE_LEVEL_KEY));
        permanentSkillSOs[3] = SkillSOKeeper.Instance.GetPermanentSkillSOByCode(3, PlayerPrefs.GetInt(ConstStrings.PERMANENT_EXTRA_GOLD_LEVEL_KEY));
        permanentSkillSOs[4] = SkillSOKeeper.Instance.GetPermanentSkillSOByCode(4, PlayerPrefs.GetInt(ConstStrings.PERMANENT_EXTRA_HP_LEVEL_KEY));
        permanentSkillSOs[5] = SkillSOKeeper.Instance.GetPermanentSkillSOByCode(5, PlayerPrefs.GetInt(ConstStrings.PERMANENT_EXTRA_HP_REGEN_LEVEL_KEY));
        permanentSkillSOs[6] = SkillSOKeeper.Instance.GetPermanentSkillSOByCode(6, PlayerPrefs.GetInt(ConstStrings.PERMANENT_EXTRA_MOVE_SPEED_Level_KEY));
        permanentSkillSOs[7] = SkillSOKeeper.Instance.GetPermanentSkillSOByCode(7, PlayerPrefs.GetInt(ConstStrings.PERMANENT_EXTRA_PROJECTILE_LEVEL_KEY));
        permanentSkillSOs[8] = SkillSOKeeper.Instance.GetPermanentSkillSOByCode(8, PlayerPrefs.GetInt(ConstStrings.PERMANENT_REDUCE_RESPAWN_TIMER_AMOUNT_LEVEL_KEY));
        permanentSkillSOs[9] = SkillSOKeeper.Instance.GetPermanentSkillSOByCode(9, PlayerPrefs.GetInt(ConstStrings.PERMANENT_EXTRA_TOWER_ATTACK_SPEED_LEVEL_KEY));
        permanentSkillSOs[10] = SkillSOKeeper.Instance.GetPermanentSkillSOByCode(10, PlayerPrefs.GetInt(ConstStrings.PERMANENT_EXTRA_TOWER_ATTACK_DAMAGE_LEVEL_KEY));
        permanentSkillSOs[11] = SkillSOKeeper.Instance.GetPermanentSkillSOByCode(11, PlayerPrefs.GetInt(ConstStrings.PERMANENT_EXTRA_TOWER_HP_LEVEL_KEY));
    
        GlobalUnitTargets.Instance.GetPlayerTarget().GetComponent<PlayerHealth>().UpdateMaxHealth();
    }

    public PermanentSkillSO GetPermanentSkillSO(int code)
    {
        return permanentSkillSOs[code];
    }

}
