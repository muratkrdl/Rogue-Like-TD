using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;

public abstract class DamageForEvolvedTowerProjectile : MonoBehaviour
{
    List<GameObject> gameObjects = new();

    bool isAvailable;

    float damage;
    DamageType damageType;

    public float GetDamage
    {
        get => damage;
    }
    public DamageType GetDamageType
    {
        get => damageType;
    }
    public bool IsAvailable
    {
        get => isAvailable;
        set => isAvailable = value;
    }

    public void SetValues(float _damage, DamageType _damageType, Vector3 _pos)
    {
        damage = _damage;
        damageType = _damageType;
        gameObjects.Clear();
        isAvailable = false;
        transform.position = _pos;
        GetComponent<Animator>().SetTrigger(ConstStrings.ANIM);
        Invoke(nameof(InkFunc), 1);
        OnSpawn();
    }

    void InkFunc()
    {
        isAvailable = true;
        transform.position = new(99,99);
        GetComponent<AudioSource>().Stop();
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag(TagManager.ENEMY) && !isAvailable && !gameObjects.Contains(other.gameObject))
        {
            gameObjects.Add(other.gameObject);
            other.GetComponent<UnitHealth>().SetHP(damage, damageType);
            OnTriggerFunc(other);
        }
    }

    protected virtual void OnSpawn() { /* */ }
    protected virtual void OnTriggerFunc(Collider2D collider2D) { /* */ }

}
