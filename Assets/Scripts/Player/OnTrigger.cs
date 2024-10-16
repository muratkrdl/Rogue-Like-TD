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
    }

    void OnTriggerExit2D(Collider2D other) 
    {
        if(other.CompareTag(TagManager.TOWER))
        {
            other.GetComponent<SpriteRenderer>().color = normalColor;
        }
    }
}
