using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTrigger : MonoBehaviour
{
    [SerializeField] Color transparentColor;
    [SerializeField] Color normalColor;

    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag(TagManager.TOWER))
        {
            other.GetComponent<SpriteRenderer>().color = transparentColor;
        }
        else if(other.CompareTag(TagManager.XPGEM))
        {
            ExperienceSystem.Instance.OnGetExperience?.Invoke(this, new() { name = other.name } );
            other.gameObject.SetActive(false);
        }
        else if(other.CompareTag(TagManager.BOSS_TREASURE))
        {
            GameStateManager.Instance.PauseGame();
            other.GetComponent<Animator>().SetTrigger(ConstStrings.ANIM);
            Invoke(nameof(InvokeBossTreasure), 0f);
            // other.GetComponent<TreasureObject>().ResetTreasureObj();
        }
    }

    void OnTriggerExit2D(Collider2D other) 
    {
        if(other.CompareTag(TagManager.TOWER))
        {
            other.GetComponent<SpriteRenderer>().color = normalColor;
        }
    }

    void InvokeBossTreasure()
    {
        ExperienceSystem.Instance.SetRandomUISkillButtons(true);
    }

}
