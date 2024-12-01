using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardTrigger : MonoBehaviour
{
    [SerializeField] Color transparentColor;
    [SerializeField] Color normalColor;

    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag(TagManager.TOWER))
        {
            other.GetComponent<SpriteRenderer>().color = transparentColor;
        }
    }

    void OnTriggerStay2D(Collider2D other) 
    {
        if(other.CompareTag(TagManager.TOWER))
        {
            if(other.GetComponent<SpriteRenderer>().color != transparentColor)
                other.GetComponent<SpriteRenderer>().color = transparentColor;
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
