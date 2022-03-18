using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Log : Target
{
    [SerializeField] private GameObject[] parts;
    
    protected override void DestroyEffect()
    {
        foreach (var part in parts)
        {
            part.transform.SetParent(transform.parent);
            part.SetActive(true);
            var direction = (transform.position - part.transform.position).normalized;
            
            var rb3d = part.GetComponent<Rigidbody>();
            rb3d.isKinematic = false;
            rb3d.useGravity = true;
            rb3d.AddForce(-direction * 8f, ForceMode.Impulse);
            rb3d.AddTorque(new Vector3(1, 0, 0), ForceMode.Impulse);

            part.GetComponent<LogPart>().Init();
        }
    }
}
