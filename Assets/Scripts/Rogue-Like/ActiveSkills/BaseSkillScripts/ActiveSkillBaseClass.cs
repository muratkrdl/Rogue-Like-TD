using System.Collections;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public abstract class ActiveSkillBaseClass : MonoBehaviour
{
    [SerializeField] int skillCode;

    CancellationTokenSource cts = new();

    CancellationTokenSource skillCDSliderCTS = new();

    Image slider;

    public bool canUseSkill = false;
    Vector2 currentScale = Vector2.one;
    float currentProjectileAmount = 1;

    protected CancellationTokenSource GetCTS
    {
        get => cts;
    }

    protected Image GetSlider
    {
        get => slider;
    }
    protected int GetSkillCode
    {
        get => skillCode;
    }
    protected bool GetCanUseSkill
    {
        get => canUseSkill;
    }
    protected Vector2 GetCurrentScale
    {
        get => currentScale;
    }
    protected float GetCurrentProjectileAmount
    {
        get => currentProjectileAmount;
    }

    protected void OnDestroy_CancelCTS()
    {
        cts.Cancel();
        skillCDSliderCTS.Cancel();
    }
    protected void SubInventoryCDEvent()
    {
        InventoryUIPanel.Instance.OnSetNewActiveSkillIcon += InventoryUIPanel_OnSetNewActiveSkillIcon;
    }
    protected void UnSubInventoryCDEvent()
    {
        InventoryUIPanel.Instance.OnSetNewActiveSkillIcon -= InventoryUIPanel_OnSetNewActiveSkillIcon;
    }
    protected void InventorySystem_OnNewSkillGain(object sender, InventorySystem.OnSkillUpdateEventArgs e)
    {
        if(e.Code == skillCode)
        {
            canUseSkill = true;
            OnSkillGainedFunc();
        }
    }
    protected void InventorySystem_OnSkillUpdate(object sender, InventorySystem.OnSkillUpdateEventArgs e)
    {
        if(e.Code == GetSkillCode)
        {
            currentScale = Vector2.one * InventorySystem.Instance.GetSkillSO(GetSkillCode).Size;
            currentProjectileAmount = InventorySystem.Instance.GetSkillSO(GetSkillCode).ProjectileCount + PermanentSkillSystem.Instance.GetPermanentSkillSO(7).Value;
            OnSkillUpdateFunc();
        }
    }
    protected void InventorySystem_OnSkillEvolved(object sender, InventorySystem.OnSkillUpdateEventArgs e) 
    { 
        if(e.Code -10 == GetSkillCode)
        {
            // EVOLVE
            EvolveSkill();
        }
    }

    void InventoryUIPanel_OnSetNewActiveSkillIcon(object sender, InventoryUIPanel.OnSetNewActiveSkillIconEventArgs e)
    {
        if(e._code == GetSkillCode)
        {
            slider = e._slider;
        }
    }

    protected virtual void OnSkillUpdateFunc() { /* */  }
    protected virtual void OnSkillGainedFunc() { /* */  }
    protected virtual void EvolveSkill() {  /* */ }

    protected IEnumerator SkillCDSlider()
    {
        float time = GetSkillCoolDown() / 20;
        slider.fillAmount = 1;
        while(true)
        {
            yield return new WaitUntil(() => !GameStateManager.Instance.GetIsGamePaused);
            yield return new WaitForSeconds(time);
            yield return new WaitUntil(() => !GameStateManager.Instance.GetIsGamePaused);
            slider.fillAmount -= .058f;
            if(slider.fillAmount < .01f)
            {
                slider.fillAmount = 0;
                break;
            }
        }
    }

    /* protected async UniTaskVoid SkillCDSlider()
    {
        float time = GetSkillCoolDown() / 20;
        slider.fillAmount = 1;
        while(true)
        {
            await UniTask.WaitUntil(() => !GameStateManager.Instance.GetIsGamePaused, cancellationToken: skillCDSliderCTS.Token);
            await UniTask.Delay(TimeSpan.FromSeconds(time));
            await UniTask.WaitUntil(() => !GameStateManager.Instance.GetIsGamePaused);
            slider.fillAmount -= .058f;
            if(slider.fillAmount < .06f)
            {
                slider.fillAmount = 0;
                Debug.Log("break amq");
                break;
            }
        }
    } */

    protected float GetSkillCoolDown()
    {
        return InventorySystem.Instance.GetSkillSO(skillCode).CooldDown - InventorySystem.Instance.GetSkillSO(skillCode).CooldDown * 
        (InventorySystem.Instance.GetSkillSO(9).Value + PermanentSkillSystem.Instance.GetPermanentSkillSO(0).Value) / 100;
    }

}
