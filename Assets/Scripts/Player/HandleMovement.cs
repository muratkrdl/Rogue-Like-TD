using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class HandleMovement : MonoBehaviour
{
    [SerializeField] GetInputs getInputs;

    [SerializeField] Rigidbody2D myRigidbody;
    [SerializeField] float moveSpeed;

    float initialMoveSpeed;

    void Start() 
    {
        initialMoveSpeed = moveSpeed;
        InventorySystem.Instance.OnSkillUpdate += InventorySystem_OnPasifeUpdate;
    }

    void InventorySystem_OnPasifeUpdate(object sender, InventorySystem.OnSkillUpdateEventArgs e)
    {
        if(e.Code == 6)
        {
            UpdateMoveSpeed();
        }
    }

    public void UpdateMoveSpeed()
    {
        moveSpeed = initialMoveSpeed + 1 * (InventorySystem.Instance.GetSkillSO(6).Value + PermanentSkillSystem.Instance.GetPermanentSkillSO(6).Value) / 100;
    }

    void FixedUpdate()
    {
        myRigidbody.MovePosition(myRigidbody.position + Time.fixedDeltaTime * moveSpeed * getInputs.GetMoveInput);
    }

    public void PlayStepSFX()
    {
        SoundManager.Instance.PlaySound2DVolume(ConstStrings.STEPS, .225f);
    }

    void OnDestroy() 
    {
        InventorySystem.Instance.OnSkillUpdate -= InventorySystem_OnPasifeUpdate;
    }

}
