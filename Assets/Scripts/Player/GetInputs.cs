using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetInputs : GamePlayMonoBehaviour
{
    Vector2 moveInput;

    Vector2 lastMoveDir;

    public Vector2 GetLastMoveDir
    {
        get => lastMoveDir;
    }

    public Vector2 GetMoveInput
    {
        get => moveInput.normalized;
    }

    void Start() 
    {
        if(GetPauseable)
            SubscribeToEvents();
    }

    void Update()
    {
        if((TryGetComponent<PlayerHealth>(out var health) && health.IsDead) || GameStateManager.Instance.GetIsGamePaused) return;

        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        if(moveX == 0 && moveY == 0 && (moveInput.x != 0 || moveInput.y != 0))
        {
            lastMoveDir = moveInput;
        }

        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");
    }

    protected override void PostPause()
    {
        ResetMoveInput();
    }

    public void ResetMoveInput()
    {
        moveInput = Vector2.zero;
    }

    void OnDestroy() 
    {
        if(GetPauseable)
            UnSubscribeToEvents();    
    }

}
