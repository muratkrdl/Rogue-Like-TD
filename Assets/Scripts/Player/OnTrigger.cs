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
    }

    void OnTriggerExit2D(Collider2D other) 
    {
        if(other.CompareTag(TagManager.TOWER))
        {
            other.GetComponent<SpriteRenderer>().color = normalColor;
        }       
    }
}
