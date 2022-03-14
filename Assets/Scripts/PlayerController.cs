using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            TouchDown();
        }
        
        if (Input.touches.Length > 0)
        {
            var ev = Input.touches[0];
            if (ev.phase == TouchPhase.Began)
                TouchDown();
        }
    }
    
    private void TouchDown()
    {
        GameManager.LevelManager.SpawnKnife();
    }
}
