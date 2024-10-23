using System;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class DarkAura : ActiveSkillBaseClass
{
    [SerializeField] Animator myAnimator;

    void Start() 
    {
        UseSkill().Forget();
        InventorySystem.Instance.OnNewSkillGain += InventorySystem_OnNewSkillGain;
    }

    async UniTaskVoid UseSkill()
    {
        await UniTask.WaitUntil(() => GetCanUseSkill);
        while (true)
        {
            await UniTask.WaitUntil(() => !GameStateManager.Instance.GetIsGamePaused);
            await UniTask.Delay(TimeSpan.FromSeconds(GetSkillCoolDown()));
            await UniTask.WaitUntil(() => !GameStateManager.Instance.GetIsGamePaused);

            Skill();
        }
    }

    void Skill()
    {
        Vector3 newScale = new( 2 * InventorySystem.Instance.GetSkillSO(15).Size, 2 * InventorySystem.Instance.GetSkillSO(15).Size, 1);
        myAnimator.transform.localScale = newScale;
        myAnimator.SetTrigger(ConstStrings.ANIM);
    }

    void OnDestroy() 
    {
        InventorySystem.Instance.OnNewSkillGain -= InventorySystem_OnNewSkillGain;
    }
}
