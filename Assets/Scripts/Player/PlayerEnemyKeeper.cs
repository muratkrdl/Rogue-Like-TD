using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEnemyKeeper : MonoBehaviour
{
    List<Transform> enemiesInRange = new();

    public bool EnemiesInRange()
    {
        return enemiesInRange.Count != 0;
    }

    public Transform GetClosestEnemy()
    {
        Transform closestEnemy = enemiesInRange[0];
        foreach(Transform item in enemiesInRange)
        {
            if(Mathf.Abs(Vector2.Distance(item.position, transform.position)) < Mathf.Abs(Vector2.Distance(closestEnemy.position, transform.position)))
            {
                closestEnemy = item;
            }
        }

        return closestEnemy;
    }
    
    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag(TagManager.ENEMY))
        {
            enemiesInRange.Add(other.transform);
        }
    }

    void OnTriggerExit2D(Collider2D other) 
    {
        if(other.CompareTag(TagManager.ENEMY))
        {
            enemiesInRange.Remove(other.transform);
        }
    }

}
