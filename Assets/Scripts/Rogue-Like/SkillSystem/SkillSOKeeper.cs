using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillSOKeeper : MonoBehaviour
{
    public static SkillSOKeeper Instance;

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

    [SerializeField] SkillSO[] beamofLight;
    [SerializeField] SkillSO[] bloodRain;
    [SerializeField] SkillSO[] brightShield; // work ??
    [SerializeField] SkillSO[] dagger;
    [SerializeField] SkillSO[] darkBlade;
    [SerializeField] SkillSO[] darkAura;
    [SerializeField] SkillSO[] fireball;
    [SerializeField] SkillSO[] spike; // work ?? 
    [SerializeField] SkillSO[] tornado;
    [SerializeField] SkillSO[] vine; // 19

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

            _ => throw new System.NotImplementedException()
        };
    }

}
