using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleMovement : GamePlayMonoBehaviour
{
    [SerializeField] GetInputs getInputs;

    [SerializeField] Rigidbody2D myRigidbody;
    [SerializeField] float moveSpeed;

    float initialMoveSpeed;

    void Start() 
    {
        initialMoveSpeed = moveSpeed;
        InventorySystem.Instance.OnSkillUpdate += InventorySystem_OnPasifeUpdate;

        if(!GetPauseable) return;

        GameStateManager.Instance.OnPause += GameStateManager_OnPause;
        GameStateManager.Instance.OnResume += GameStateManager_OnResume;
    }

    void InventorySystem_OnPasifeUpdate(object sender, InventorySystem.OnSkillUpdateEventArgs e)
    {
        if(e.Code == 6)
        {
            moveSpeed = initialMoveSpeed + initialMoveSpeed /2 * InventorySystem.Instance.GetSkillSO(6).Value / 100;
        }
    }

    void FixedUpdate()
    {
        myRigidbody.MovePosition(myRigidbody.position + Time.fixedDeltaTime * moveSpeed * getInputs.GetMoveInput);
    }

    void OnDestroy() 
    {
        InventorySystem.Instance.OnSkillUpdate += InventorySystem_OnPasifeUpdate;
    }

}
