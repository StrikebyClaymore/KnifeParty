using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogPart : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float gravityScale = 3.0f;
    
    public void Init()
    {
        Invoke(nameof(AddForce), 0.3f);
        Invoke(nameof(DestroySelf), 2.5f);
    }

    private void AddForce()
    {
        rb.drag = 0;
        rb.AddForce(Physics.gravity * gravityScale * Time.fixedDeltaTime, ForceMode.Acceleration);
    }

    private void DestroySelf()
    {
        Destroy(gameObject);
    }
}
