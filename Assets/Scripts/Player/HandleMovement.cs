using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleMovement : MonoBehaviour
{
    [SerializeField] GetInputs getInputs;

    [SerializeField] Rigidbody2D myRigidbody;
    [SerializeField] float moveSpeed;

    void FixedUpdate()
    {
        myRigidbody.MovePosition(myRigidbody.position + GlobalValues.Instance.GetFixedDeltaTime * moveSpeed * getInputs.GetMoveInput);
    }

}
