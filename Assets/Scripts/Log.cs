using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Log : MonoBehaviour
{
    [SerializeField] private float rotateSpeed = 1.5f;
    
    private void FixedUpdate()
    {
        transform.Rotate(0, 0, rotateSpeed);
    }
}
