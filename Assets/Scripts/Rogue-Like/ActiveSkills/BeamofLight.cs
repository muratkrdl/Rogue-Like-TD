using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class BeamofLight : ActiveSkillBaseClass
{
    [SerializeField] GameObject projectilePrefab;

    Vector2[] currentGoPoses = new Vector2[8];

    int posCounter;

    void Start() 
    {
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
    }

    async UniTaskVoid UseSkill()
    {
        await UniTask.WaitUntil(() => GetCanUseSkill);
        while (true)
        {
            // if(GameStateManager.Instance.GetIsGamePaused) return;
            await UniTask.WaitUntil(() => !GameStateManager.Instance.GetIsGamePaused);
            await UniTask.Delay(TimeSpan.FromSeconds(GetSkillCoolDown()));
            await UniTask.WaitUntil(() => !GameStateManager.Instance.GetIsGamePaused);

            Skill();
        }
    }

    void Skill()
    {
        var projectile = ActiveSkillProjectileObjectPool.Instance.GetProjectile(0);

        projectile.SetLookPos(currentGoPoses[posCounter],transform.position);
        projectile.SetBaseClassValues(InventorySystem.Instance.GetSkillSO(10).Value);
        projectile.GetComponent<Animator>().SetTrigger(ConstStrings.ACTIVE_SKILLS_ANIM);
        posCounter++;
        if(posCounter > 7)
            posCounter = 0;
    }

    void OnDestroy() 
    {
        InventorySystem.Instance.OnNewSkillGain -= InventorySystem_OnNewSkillGain;
    }

}
