using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetRotation : MonoBehaviour
{
    [SerializeField] private float maxRotateSpeed = 4.0f;
    [SerializeField] private float minRotateSpeed = 1.0f;
    [SerializeField] private float rotateSpeed = 1.5f;

    private int _speedDirection = 1;
    private int _moveDirection = 1;

    private void Update()
    {
        SimpleDirectonChanger();
    }

    private void FixedUpdate()
    {
        transform.Rotate(0, 0, _moveDirection * rotateSpeed);
    }

    private void SimpleDirectonChanger()
    {
        rotateSpeed += _speedDirection * Time.deltaTime;
        if (rotateSpeed >= maxRotateSpeed)
            _speedDirection *= -1;
        if (rotateSpeed <= minRotateSpeed)
        {
            _speedDirection *= -1;
            _moveDirection *= -1;
        }
    }
}
