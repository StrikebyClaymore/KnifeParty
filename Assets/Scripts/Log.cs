using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Log : MonoBehaviour
{
    [SerializeField] private float rotateSpeed = 1.5f;
    [SerializeField] private int hp = 5; 
    
    private void FixedUpdate()
    {
        transform.Rotate(0, 0, rotateSpeed);
    }

    public void GetHit()
    {
        hp = Mathf.Max(0, hp - 1);
        if (hp == 0)
            Destroy(gameObject);
        GameManager.LevelManager.LevelCompleted();
    }
}
