using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardSetTarget : MonoBehaviour
{
    [SerializeField] TowerEnemyKeeper towerEnemyKeeper;
    Transform currentTarget;

    public TowerEnemyKeeper TowerEnemyKeeper
    {
        get => towerEnemyKeeper;
        set => towerEnemyKeeper = value;
    }
    public Transform GetCurrentTarget
    {
        get => currentTarget;
    }

    public void ChangeCurrentTarget(Transform changeTransform)
    {
        currentTarget = changeTransform;
    }

    public void PlaySFX()
    {
        GetComponent<AudioSource>().Play();
    }

}
