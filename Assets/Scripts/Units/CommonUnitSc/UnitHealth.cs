using System.Collections;
using Cysharp.Threading.Tasks;
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

        if(amount % 1 == 0)
        {
            amount = SetNewDamage(amount, damageType);
        }

        currentHealth -= amount;

        if(currentHealth <= 0)
        {
            unitValues.IsDead = true;
            unitValues.GetUnitMove().StopUnit(true);
            unitValues.GetUnitAnimator().SetTrigger(ConstStrings.UNIT_ANIMATOR_DEATH);
            IUnitState state;

            if(unitValues.GetIsEnemy)
            {
                int xpObjCode = 0;
                if(unitValues.GetIsSpecial)
                    state = new SpecialEnemyIdleState();
                else
                    state = new EnemyIdleState();

                if(unitValues.GetIsBoss)
                {
                    TreasureObjectPool.Instance.GetTreasureObj().SetValues(transform.position);
                    xpObjCode = 2;
                }

                GlobalUnitTargets.Instance.OnAnEnemyDead?.Invoke(this, new() { deadUnit = unitValues } );

                var obj = ExperienceObjectPool.Instance.GetExperienceObj(xpObjCode);
                obj.gameObject.SetActive(true);
                obj.transform.position = transform.position;
                
                Bank.Instance.OnChangeMoneyAmount?.Invoke(this, new() { amount = 
                Random.Range(3 + PermanentSkillSystem.Instance.GetPermanentSkillSO(3).Value, 8 + PermanentSkillSystem.Instance.GetPermanentSkillSO(3).Value) } );
            }
            else
            {
                state = new GuardIdleState();
                GlobalUnitTargets.Instance.OnAnGuardDead?.Invoke(this, new() { deadUnit = unitValues } );
            }

            if(Random.Range(0, 36) == 24)
            {
                Bank.Instance.OnPermanentMoneyGained?.Invoke(this, new() { amount = 1 } );
                var obj = FoodObjectPool.Instance.GetFoodObj();
                obj.transform.position = unitValues.transform.position;
                obj.SetActive(true);
            }
            unitValues.GetUnitStateController().ChangeState(state);
            unitValues.ResetAllValues();

            if(specialAnimator != null)
            {
                specialAnimator.SetTrigger(ConstStrings.ANIM);
            }
        }
    }

    public void TakeDamageFromPlayer(float amount, DamageType damageType, int damageColorCode, Vector2 direction, float force)
    {
        unitValues.GetRigidbody2D().AddForce(direction * force);
        amount = SetNewDamageFromPlayer(amount, damageType, InventorySystem.Instance.GetSkillSO(4).Value, InventorySystem.Instance.GetSkillSO(5).Value);
        amount *= (100 + InventorySystem.Instance.GetSkillSO(7).Value + PermanentSkillSystem.Instance.GetPermanentSkillSO(1).Value) / 100 ;
        SetHP(amount, damageType);
        InventorySystem.Instance.OnDamageWithActiveSkills?.Invoke(this, new() { damage = amount } );
        unitValues.GetUnitFlashFX().FlashFX(.125f, damageColorCode).Forget();
        SoundManager.Instance.PlaySound2DVolume(ConstStrings.HIT, .35f);
    }

    float SetNewDamage(float amount, DamageType damageType)
    {
        float returnInteger = amount;
        int towerCode = 0;
        if(unitValues.TowerBasePosition != null)
        {
            towerCode = GetComponentInParent<TowerInfoKeeper>().GetCurrentTowerCode;
        }

        if(damageType == DamageType.physical)
        {
            returnInteger *= (100-(float)unitValues.UnitSO.Armor*16) / 100;
            if(towerCode == 9)
                returnInteger = 0;
        }
        else if(damageType == DamageType.magic)
        {
            returnInteger *= (100-(float)unitValues.UnitSO.MagicResistance*16) / 100;
            if(towerCode == 8)
                returnInteger = 0;
        }

        return returnInteger;
    }

    float SetNewDamageFromPlayer(float amount, DamageType damageType, int lethality, int magicPenetration)
    {
        float returnInteger = amount;

        if(damageType == DamageType.physical)
        {
            float calculateArmor = (float)unitValues.UnitSO.Armor * 16 * ((100 - (float)lethality) / 100);
            returnInteger *= (100 - calculateArmor) / 100;
        }
        else if(damageType == DamageType.magic)
        {
            float calculateMR = (float)unitValues.UnitSO.MagicResistance * 16 * ((100 - (float)magicPenetration) / 100);
            returnInteger *= (100 - calculateMR) / 100;
        }

        if(returnInteger % 1 == 0)
        {
            returnInteger += 0.001f;
        }

        return returnInteger;
    }

    public void DamageWithPoison(float damage, int duration)
    {
        PoisonEnemy(damage, duration).Forget();
    }

    async UniTaskVoid PoisonEnemy(float damage, int duration)
    {
        for (int i = 0; i < duration; i++)
        {
            await UniTask.Delay(System.TimeSpan.FromSeconds(1));

            unitValues.GetUnitFlashFX().FlashFX(.125f, 1).Forget();
            SetHP(damage, DamageType.truedamage);
        }
    }

}
