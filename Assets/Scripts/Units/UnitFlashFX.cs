using System;
using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class UnitFlashFX : MonoBehaviour
{
    [SerializeField] Material flashMaterial;

    SpriteRenderer spriteRenderer;
    Material initialMaterial;

    void Start() 
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        initialMaterial = spriteRenderer.material;
    }

    public async UniTaskVoid FlashFX(float duration)
    {
        spriteRenderer.material = flashMaterial;
        await UniTask.Delay(TimeSpan.FromSeconds(duration));
        spriteRenderer.material = initialMaterial;
    }

}
