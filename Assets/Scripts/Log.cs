using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Log : MonoBehaviour
{
    [SerializeField] private GameObject[] parts;
    
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
            GameManager.LevelManager.LevelCompleted(); // TODO: сделать чтобы бревно разлеталось на куски

            for (int i = 0; i < parts.Length; i++)
            {
                var part = parts[i];
                part.transform.SetParent(transform.parent.parent);
                part.SetActive(true);
                //var angle = Random.Range(10, 30);
                //var rotation = Quaternion.Euler(new Vector3(0, 0, angle));
                var direction = (transform.position - part.transform.position).normalized;//rotation * Vector3.up;
                
                var rb = part.GetComponent<Rigidbody>();
                rb.isKinematic = false;
                rb.useGravity = true;
                rb.AddForce(-direction * 5f, ForceMode.Impulse);

                part.GetComponent<LogPart>().Init();
                //part1.GetComponent<Rigidbody>().AddTorque(1, ForceMode2D.Force);
            }

            Destroy(gameObject);
        }
    }
}
