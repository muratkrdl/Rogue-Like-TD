using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerForward : MonoBehaviour
{
    GetInputs getInputs;

    void Start() 
    {
        getInputs = GetComponentInParent<GetInputs>();
    }

    void Update()
    {
        Vector2 offset;
        if(getInputs.GetMoveInput.x != 0 || getInputs.GetMoveInput.y != 0)
        {
            offset = getInputs.GetMoveInput;
            transform.localPosition = offset / 3;
        }
    }
}
