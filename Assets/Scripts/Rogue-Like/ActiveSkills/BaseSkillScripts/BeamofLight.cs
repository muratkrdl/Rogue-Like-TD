using System;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class BeamofLight : ActiveSkillBaseClass
{
    Vector2[] currentGoPoses = new Vector2[8];

    Color spriteColor;

    int posCounter;
    int projectileCode = 0;

    void Start() 
    {
        spriteColor = Color.white;
        currentGoPoses[0] = Vector2.left;
        currentGoPoses[1] = new(-1,1);
        currentGoPoses[2] = Vector2.up;
        currentGoPoses[3] = new(1,1);
        currentGoPoses[4] = Vector2.right;
        currentGoPoses[5] = new(1,-1);
        currentGoPoses[6] = Vector2.down;
        currentGoPoses[7] = new(-1,-1);
        UseSkill().Forget();
        InventorySystem.Instance.OnNewSkillGain += InventorySystem_OnNewSkillGain;
        InventorySystem.Instance.OnSkillEvolved += InventorySystem_OnSkillEvolved;
        SubInventoryCDEvent();
    }

    async UniTaskVoid UseSkill()
    {
        await UniTask.WaitUntil(() => GetCanUseSkill);
        while (true)
        {
            await UniTask.WaitUntil(() => GlobalUnitTargets.Instance.CanPlayerUseSkill(), cancellationToken: GetCTS.Token);
            await UniTask.Delay(TimeSpan.FromSeconds(GetSkillCoolDown()));

            Skill();
        }
    }

    void Skill()
    {
        if(!GlobalUnitTargets.Instance.CanPlayerUseSkill()) return;

        StopAllCoroutines();
        StartCoroutine(nameof(SkillCDSlider));

        var projectile = ActiveSkillProjectileObjectPool.Instance.GetProjectile(projectileCode);

        SoundManager.Instance.PlaySound2D(ConstStrings.BOF);

        projectile.SetMoveableProjectile(currentGoPoses[posCounter], transform.position, true);
        projectile.GetComponent<Animator>().SetTrigger(ConstStrings.ANIM);
        projectile.GetComponent<SkillProjectileDamagerBaseClass>().SetDamageOnSpawn();
        posCounter++;
        
        if(posCounter > 7)
            posCounter = 0;
    }

    protected override void EvolveSkill()
    {
        projectileCode = 8;
    }

    void OnDestroy() 
    {
        InventorySystem.Instance.OnNewSkillGain -= InventorySystem_OnNewSkillGain;
        InventorySystem.Instance.OnSkillEvolved -= InventorySystem_OnSkillEvolved;
        UnSubInventoryCDEvent();
        OnDestroy_CancelCTS();
    }

}
