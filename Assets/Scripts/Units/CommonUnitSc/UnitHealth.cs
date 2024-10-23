using System.Collections;
using UnityEngine;

public class UnitHealth : MonoBehaviour, IDamageable
{
    [SerializeField] Animator specialAnimator;

    [SerializeField] UnitValues unitValues;

    int currentHealth = 10;

    public int CurrenHealth
    {
        get => currentHealth;
        set => currentHealth = value;
    }

    public void TakeDamage(int amount, DamageType damageType)
    {
        if(unitValues.IsDead) return;

        amount = SetNewDamage(amount, damageType);

        currentHealth -= amount;

        if(currentHealth <= 0)
        {
            unitValues.IsDead = true;
            unitValues.GetUnitMove().StopUnit(true);
            unitValues.GetUnitAnimator().SetTrigger(ConstStrings.UNIT_ANIMATOR_DEATH);
            IUnitState state;

            if(unitValues.GetIsEnemy)
            {
                if(unitValues.GetIsSpecial)
                    state = new SpecialEnemyIdleState();
                else
                    state = new EnemyIdleState();

                GlobalUnitTargets.Instance.OnAnEnemyDead?.Invoke(this, new() { deadUnit = unitValues } );
            }
            else
            {
                state = new GuardIdleState();
                GlobalUnitTargets.Instance.OnAnGuardDead?.Invoke(this, new() { deadUnit = unitValues } );
            }

            ExperienceObjectPool.Instance.GetExperienceObj(0).transform.position = transform.position;

            Bank.Instance.OnChangeMoneyAmount?.Invoke(this, new() { amount = Random.Range(1,5) } );

            unitValues.GetUnitStateController().ChangeState(state);
            unitValues.ResetAllValues();

            if(specialAnimator != null)
            {
                specialAnimator.SetTrigger(ConstStrings.ANIM);
            }
        }
    }

    public void TakeDamageFromPlayer(int amount, DamageType damageType)
    {
        SetNewDamageFromPlayer(amount, damageType, InventorySystem.Instance.GetSkillSO(4).Value, InventorySystem.Instance.GetSkillSO(5).Value);
        amount += amount * InventorySystem.Instance.GetSkillSO(4).Value / 100;
        TakeDamage(amount, damageType);
    }

    int SetNewDamage(int amount, DamageType damageType)
    {
        int returnInteger = amount;

        if(damageType == DamageType.physical)
        {
            returnInteger *= (100-unitValues.UnitSO.Armor*20) / 100;
        }
        else if(damageType == DamageType.magic)
        {
            returnInteger *= (100-unitValues.UnitSO.MagicResistance*20) / 100;
        }

        return returnInteger;
    }

    int SetNewDamageFromPlayer(int amount, DamageType damageType, int lethality, int magicPenetration)
    {
        int returnInteger = amount;

        if(damageType == DamageType.physical)
        {
            float calculateArmor = unitValues.UnitSO.Armor * (100 - lethality) / 100;
            returnInteger *= (int)(100 - calculateArmor * 20) / 100;
        }
        else if(damageType == DamageType.magic)
        {
            float calculateMR = unitValues.UnitSO.MagicResistance * (100 - magicPenetration) / 100;
            returnInteger *= (int)(100 - calculateMR * 20) / 100;
        }

        return returnInteger;
    }

}
