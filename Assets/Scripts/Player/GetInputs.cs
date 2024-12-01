using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
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
        GameStateManager.Instance.OnPause += GameStateManager_OnPause;
        GameStateManager.Instance.OnResume += GameStateManager_OnResume;
    }

    void Update()
    {
        if(TryGetComponent<PlayerHealth>(out var playerHealth) && playerHealth.GetIsDead) return;

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
        moveInput = Vector2.zero;
    }

}
