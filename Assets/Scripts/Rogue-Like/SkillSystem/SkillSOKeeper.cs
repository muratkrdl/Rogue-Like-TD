using UnityEngine;

public class SkillSOKeeper : MonoBehaviour
{
    public static SkillSOKeeper Instance;

    [SerializeField] SkillSO[] EvolvedActiveSkillSOs;

    [Space(20)]

    [SerializeField] SkillSO[] armor;
    [SerializeField] SkillSO[] magicResistance;
    [SerializeField] SkillSO[] extraHP;
    [SerializeField] SkillSO[] healthRegen;
    [SerializeField] SkillSO[] lethality;
    [SerializeField] SkillSO[] magicPenetration;
    [SerializeField] SkillSO[] extraMoveSpeed;
    [SerializeField] SkillSO[] extraDamagePercent;
    [SerializeField] SkillSO[] lifeStealPercent;
    [SerializeField] SkillSO[] coolDownPercent; // 9

    [Space(10)]

    [SerializeField] SkillSO[] beamofLight;
    [SerializeField] SkillSO[] bloodRain;
    [SerializeField] SkillSO[] brightShield;
    [SerializeField] SkillSO[] dagger;
    [SerializeField] SkillSO[] darkBlade;
    [SerializeField] SkillSO[] darkAura;
    [SerializeField] SkillSO[] fireball;
    [SerializeField] SkillSO[] spike;
    [SerializeField] SkillSO[] tornado;
    [SerializeField] SkillSO[] vine; // 19

    [Space(20)]

    [SerializeField] PermanentSkillSO[] permanentExtraCooldown;
    [SerializeField] PermanentSkillSO[] permanentextraDamage;
    [SerializeField] PermanentSkillSO[] permanentExtraExperience;
    [SerializeField] PermanentSkillSO[] permanentExtraGold;
    [SerializeField] PermanentSkillSO[] permanentextraHP;
    [SerializeField] PermanentSkillSO[] permanentextraHPRegen;
    [SerializeField] PermanentSkillSO[] permanentextraMoveSpeed;
    [SerializeField] PermanentSkillSO[] permanentExtraProjectile;
    [SerializeField] PermanentSkillSO[] PermanentReduceRespawnTimerAmount;
    [SerializeField] PermanentSkillSO[] ExtraTowerAttackSpeed;
    [SerializeField] PermanentSkillSO[] ExtraTowerDamage;
    [SerializeField] PermanentSkillSO[] ExtraTowerHP;

    [Space(20)]

    [SerializeField] SkillSO[] skillFulledSO;

    void Awake() 
    {
        Instance = this;
    }

    public SkillSO GetSkillSOByCode(int code, int level)
    {
        return code switch
        {
            0 => armor[level],
            1 => magicResistance[level],
            2 => extraHP[level],
            3 => healthRegen[level],
            4 => lethality[level],
            5 => magicPenetration[level],
            6 => extraMoveSpeed[level],
            7 => extraDamagePercent[level],
            8 => lifeStealPercent[level],
            9 => coolDownPercent[level],

            10 => beamofLight[level],
            11 => bloodRain[level],
            12 => brightShield[level],
            13 => dagger[level],
            14 => darkBlade[level],
            15 => darkAura[level],
            16 => fireball[level],
            17 => spike[level],
            18 => tornado[level],
            19 => vine[level],

            _ => EvolvedActiveSkillSOs[code-20],
        };
    }

    public SkillSO GetEvolvedSkillSOByCode(int code)
    {
        return EvolvedActiveSkillSOs[code];
    }

    public PermanentSkillSO GetPermanentSkillSOByCode(int code, int level)
    {
        return code switch
        {
            0 => permanentExtraCooldown[level],
            1 => permanentextraDamage[level],
            2 => permanentExtraExperience[level],
            3 => permanentExtraGold[level],
            4 => permanentextraHP[level],
            5 => permanentextraHPRegen[level],
            6 => permanentextraMoveSpeed[level],
            7 => permanentExtraProjectile[level],
            8 => PermanentReduceRespawnTimerAmount[level],
            9 => ExtraTowerAttackSpeed[level],
            10 => ExtraTowerDamage[level],
            11 => ExtraTowerHP[level],
            _ => throw new System.NotImplementedException()
        };
    }

    public SkillSO GetSkillFulledSO(int code)
    {
        return skillFulledSO[code];
    }

}
