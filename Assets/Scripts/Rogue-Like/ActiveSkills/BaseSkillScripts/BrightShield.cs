using System;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class BrightShield : ActiveSkillBaseClass
{
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
        InventorySystem.Instance.OnNewSkillGain += InventorySystem_OnNewSkillGain;
        OnTakeDamage += BrightShield_OnTakeDamage;
    }

    void BrightShield_OnTakeDamage(object sender, OnTakeDamageEventArgs e)
    {
        if(GameStateManager.Instance.GetIsGamePaused || InventorySystem.Instance.GetSkillSO(GetSkillCode).Value == 0) return;

        if(e.IsDamageFromEnemy)
        {
            currentDamageCounter++;

            if(currentDamageCounter >= InventorySystem.Instance.GetSkillSO(GetSkillCode).Value *2)
            {
                if(myAnimator.GetComponent<SpriteRenderer>().sprite == null)
                {
                    myAnimator.SetTrigger(ConstStrings.ACTIVE_SKILLS_ANIM);
                    GetComponentInParent<PlayerHealth>().SetCanTakeDamage(false);
                }
                else
                {
                    myAnimator.SetTrigger(ConstStrings.ACTIVE_SKILLS_FINISH);
                    currentDamageCounter = 0;
                }
            }
            //  else if(currentDamageCounter > InventorySystem.Instance.GetSkillSO(GetSkillCode).Value *2)
            //  {
            //      
            //  }
        }
    }

    void OnDestroy() 
    {
        InventorySystem.Instance.OnNewSkillGain -= InventorySystem_OnNewSkillGain;
        OnTakeDamage -= BrightShield_OnTakeDamage;
    }

}
