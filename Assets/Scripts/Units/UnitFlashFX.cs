using System;
using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class UnitFlashFX : MonoBehaviour
{
    [SerializeField] Material flashMaterial;
    [SerializeField] Material poisonMaterial;
    [SerializeField] Material bloodMaterial;

    SpriteRenderer spriteRenderer;
    Material initialMaterial;

    void Start() 
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        initialMaterial = spriteRenderer.material;
    }

    public async UniTaskVoid FlashFX(float duration, int code)
    {
        spriteRenderer.material = code switch
        {
            0 => flashMaterial,
            1 => poisonMaterial,
            2 => bloodMaterial,
            _ => throw new NotImplementedException(),
        };
        await UniTask.Delay(TimeSpan.FromSeconds(duration));
        spriteRenderer.material = initialMaterial;
    }

}
