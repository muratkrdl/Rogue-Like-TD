using System;
using UnityEngine;

public class BrightShield : ActiveSkillBaseClass
{
    [SerializeField] BrightShieldDamager brightShieldDamager;

    [SerializeField] AudioSource loopSFX;

    public EventHandler<OnTakeDamageEventArgs> OnTakeDamage;
    public class OnTakeDamageEventArgs : EventArgs
    {
        public float damage;
        public bool IsDamageFromEnemy
        {
            get => damage > 0;
        }
    }

    [SerializeField] Animator myAnimator;

    int currentDamageCounter = 0;

    void Start() 
    {
        OnTakeDamage += BrightShield_OnTakeDamage;
        InventorySystem.Instance.OnNewSkillGain += InventorySystem_OnNewSkillGain;
        InventorySystem.Instance.OnSkillEvolved += InventorySystem_OnSkillEvolved;
        SubInventoryCDEvent();
    }

    protected override void OnSkillUpdateFunc()
    {
        brightShieldDamager.SetDamageOnSpawn();
    }

    protected override void OnSkillGainedFunc()
    {
        brightShieldDamager.SetDamageOnSpawn();
    }

    void BrightShield_OnTakeDamage(object sender, OnTakeDamageEventArgs e)
    {
        if(GameStateManager.Instance.GetIsGamePaused || InventorySystem.Instance.GetSkillSO(GetSkillCode).Value == 0) return;

        if(e.IsDamageFromEnemy)
        {
            currentDamageCounter++;

            if(currentDamageCounter >= InventorySystem.Instance.GetSkillSO(GetSkillCode).Value)
            {
                if(myAnimator.GetComponent<SpriteRenderer>().sprite == null)
                {
                    myAnimator.SetTrigger(ConstStrings.ANIM);
                    GetComponentInParent<PlayerHealth>().SetCanTakeDamage(false);
                    loopSFX.Play();
                }
                else
                {
                    loopSFX.Stop();
                    myAnimator.SetTrigger(ConstStrings.ACTIVE_SKILLS_FINISH);
                    currentDamageCounter = 0;
                }
            }
        }
    }

    protected override void EvolveSkill()
    {
        myAnimator.GetComponent<SpriteRenderer>().color = Color.green;
    }

    void OnDestroy() 
    {
        InventorySystem.Instance.OnNewSkillGain -= InventorySystem_OnNewSkillGain;
        InventorySystem.Instance.OnSkillEvolved -= InventorySystem_OnSkillEvolved;
        UnSubInventoryCDEvent();
        OnTakeDamage -= BrightShield_OnTakeDamage;
    }

}
