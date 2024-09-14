using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    ProjectiileSO projectiileSO;

    Transform target;

    bool isAvailable = false;

    public bool GetIsAvailable
    {
        get
        {
            return isAvailable;
        }
    }

    public void SetValues(Transform target, Transform projectileOutPos, ProjectiileSO projectiileSO)
    {
        transform.position = projectileOutPos.position;
        this.target = target;
        this.projectiileSO = projectiileSO;
        isAvailable = false;
        GetComponent<SpriteRenderer>().enabled = true;
    }

    void Update() 
    {
        if(isAvailable) return;

        Quaternion rotation = Quaternion.LookRotation(target.transform.position - transform.position ,transform.TransformDirection(Vector3.up));
        transform.SetPositionAndRotation(Vector2.MoveTowards(transform.position, target.position, projectiileSO.Speed * GlobalValues.Instance.GetDeltaTime), new Quaternion( 0 , 0 , rotation.z , rotation.w ));
    
        if(Mathf.Abs(Vector2.Distance(transform.position, target.position)) <= .2f)
        {
            // Damage
            target.GetComponent<IDamageable>().TakeDamage(projectiileSO.Damage);
            isAvailable = true;
            GetComponent<SpriteRenderer>().enabled = false;
            VFX();
        }
    }

    void VFX()
    {
        
    }

}
