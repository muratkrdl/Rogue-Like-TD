using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetInputs : MonoBehaviour
{
    Vector2 moveInput;

    Vector2 lastMoveDir;

    public Vector2 GetLastMoveDir
    {
        get
        {
            return lastMoveDir;
        }
    }

    public Vector2 GetMoveInput
    {
        get
        {
            return moveInput.normalized;
        }
    }

    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        if(moveX == 0 && moveY == 0 && (moveInput.x != 0 || moveInput.y != 0))
        {
            lastMoveDir = moveInput;
        }

        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");
    }

}
