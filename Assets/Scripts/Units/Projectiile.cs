using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectiile : MonoBehaviour
{
    public ProjectiileSO ProjectiileSO { get; set; }

    public Transform Target { get; set; }

    void Update() 
    {
        Quaternion rotation = Quaternion.LookRotation(Target.transform.position - transform.position ,transform.TransformDirection(Vector3.up));
        transform.SetPositionAndRotation(Vector2.MoveTowards(transform.position, Target.position, ProjectiileSO.Speed * GlobalValues.Instance.GetDeltaTime), new Quaternion( 0 , 0 , rotation.z , rotation.w ));
    }

}
