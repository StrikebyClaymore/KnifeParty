using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Border : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D other)
    {
        Destroy(other.gameObject);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.enabled)
            Destroy(other.gameObject);
        Debug.Log(other.name);
    }
}
