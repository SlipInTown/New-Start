using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSettings : MonoBehaviour
{

    [SerializeField,Range(0f,1f)]
    float RotateSpeed;

    void FixedUpdate()
    {
        transform.Rotate(transform.right, RotateSpeed, Space.Self);
    }
}

