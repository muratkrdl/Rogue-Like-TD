using System.Collections;
using UnityEngine;

public class UnitHealth : MonoBehaviour, IDamageable
{
    [SerializeField] Animator specialAnimator;

    [SerializeField] UnitValues unitValues;

    float currentHealth = 10;

    public float CurrenHealth
    {
        get => currentHealth;
        set => currentHealth = value;
    }

    public void SetHP(float amount, DamageType damageType)
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

    public void TakeDamageFromPlayer(float amount, DamageType damageType)
    {
        amount = SetNewDamageFromPlayer(amount, damageType, InventorySystem.Instance.GetSkillSO(4).Value, InventorySystem.Instance.GetSkillSO(5).Value);
        amount = amount * (100 + InventorySystem.Instance.GetSkillSO(7).Value) / 100;
        SetHP(amount, damageType);
        InventorySystem.Instance.OnDamageWithActiveSkills?.Invoke(this, new() { damage = amount } );
        unitValues.GetUnitFlashFX().FlashFX(.125f).Forget();
    }

    float SetNewDamage(float amount, DamageType damageType)
    {
        float returnInteger = amount;

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

    float SetNewDamageFromPlayer(float amount, DamageType damageType, int lethality, int magicPenetration)
    {
        float returnInteger = amount;

        if(damageType == DamageType.physical)
        {
            float calculateArmor = (float)unitValues.UnitSO.Armor * 20 * ((100 - (float)lethality) / 100);
            returnInteger *= (100 - calculateArmor * 20) / 100;
        }
        else if(damageType == DamageType.magic)
        {
            float calculateMR = (float)unitValues.UnitSO.MagicResistance * 20 * ((100 - (float)magicPenetration) / 100);
            returnInteger *= (100 - calculateMR * 20) / 100;
        }

        return returnInteger;
    }

}
