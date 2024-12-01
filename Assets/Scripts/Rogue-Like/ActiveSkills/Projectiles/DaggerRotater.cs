using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DaggerRotater : MonoBehaviour
{
    [SerializeField] float rotateSpeed;

    void Update()
    {
        transform.Rotate(rotateSpeed * Time.deltaTime * Vector3.forward);
    }
}
