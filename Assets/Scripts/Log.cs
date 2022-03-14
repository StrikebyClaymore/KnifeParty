using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Log : MonoBehaviour
{
    [SerializeField] private float rotateSpeed = 1.5f;
    [SerializeField] private int maxHp = 7;
    private int hp;

    private void Start()
    {
        hp = maxHp;
    }

    private void FixedUpdate()
    {
        transform.Rotate(0, 0, rotateSpeed);
    }

    public void SetHp(int hp)
    {
        this.hp = hp;
    }
    
    public void GetHit()
    {
        hp = Mathf.Max(0, hp - 1);
        if (hp == 0)
        {
            Destroy(gameObject);
            GameManager.LevelManager.LevelCompleted(); // TODO: сделать чтобы бревно разлеталось на куски
        }
    }
}
