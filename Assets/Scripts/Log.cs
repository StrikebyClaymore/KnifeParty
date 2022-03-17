using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Log : MonoBehaviour
{
    [SerializeField] private GameObject[] parts;
    
    [SerializeField] private float rotateSpeed = 1.5f;
    private int hp;

    private void FixedUpdate()
    {
        transform.Rotate(0, 0, rotateSpeed);
    }

    public void SetHp(int hp)
    {
        this.hp = hp;
    }
    
    public void GetHit(GameObject knife)
    {
        hp = Mathf.Max(0, hp - 1);
        
        HitEffect();
        
        if (hp == 0)
        {
            StartCoroutine(DestroySelf(knife));
        }
    }

    private IEnumerator DestroySelf(GameObject knife)
    {
        yield return new WaitForSeconds(0.05f);
        
        knife.layer = LayerMask.NameToLayer("FallObject");
        knife.transform.SetParent(transform.parent);
        var angle = Random.Range(-15, 15);
        var rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        var direction = rotation * Vector3.up;
        var rb = knife.GetComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Dynamic;
        rb.gravityScale = 2.5f;
        rb.AddForce(direction * 15, ForceMode2D.Impulse);
        rb.AddTorque(30, ForceMode2D.Force);
        
        for (int i = 0; i < parts.Length; i++)
        {
            var part = parts[i];
            part.transform.SetParent(transform.parent);
            part.SetActive(true);
            direction = (transform.position - part.transform.position).normalized;
            
            var rb3d = part.GetComponent<Rigidbody>();
            rb3d.isKinematic = false;
            rb3d.useGravity = true;
            rb3d.AddForce(-direction * 8f, ForceMode.Impulse);
            rb3d.AddTorque(new Vector3(1, 0, 0), ForceMode.Impulse);

            part.GetComponent<LogPart>().Init();
        }

        for(int i = 0; i < transform.childCount; i++)
        {
            var child = transform.GetChild(i);
            
            if(child.gameObject == knife)
                continue;
            
            child.gameObject.layer = LayerMask.NameToLayer("FallObject");
            child.SetParent(transform.parent);
            rb = child.GetComponent<Rigidbody2D>();
            rb.bodyType = RigidbodyType2D.Dynamic;
            rb.gravityScale = 1.5f;
            direction = -(transform.position - child.position).normalized;
            rb.AddForce(direction * 8f, ForceMode2D.Impulse);
            rb.AddTorque(90, ForceMode2D.Force);
        }

        GameManager.Player.enabled = false;
        
        //GameManager.Vibrate();
        
        GameManager.LevelManager.Invoke(nameof(GameManager.LevelManager.LevelCompleted), 1.0f);
        Destroy(gameObject);
    }

    private void HitEffect()
    {
        GameManager.LevelManager.hitEffect.Play();
    }
}
