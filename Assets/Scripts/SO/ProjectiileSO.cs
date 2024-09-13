using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewProjectiileSO", menuName = "ProjectiileSO")]
public class ProjectiileSO : ScriptableObject
{
    [field: SerializeField] public float Damage { get; private set; }
    [field: SerializeField] public float Speed { get; private set; }
}
