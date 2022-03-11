using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class Knife : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Collider2D knifeCollider;
    
    [SerializeField] private float throwForce = 30f;
    [SerializeField] private float fallForce = 20f;
    [SerializeField] private float torqueForce = 720f;
    [SerializeField] private float knifeInLogDisplacement = 0.6f;
    private bool _isAttachedToLog;
    
    [Header("Tween params")]
    private Vector3 _tweenStart;
    private Vector3 _tweenEnd;
    [SerializeField] private float tweenOffsetY = 2.5f;
    [SerializeField] private float tweenScale = 0.2f;
    [SerializeField] private float tweenStopDistance = 0.2f;
    private bool _isOnTween;

    private void Start()
    {
        _tweenStart = transform.position;
        _tweenEnd = new Vector3(0, _tweenStart.y + tweenOffsetY, 0);
        rb.bodyType = RigidbodyType2D.Kinematic;
        knifeCollider.enabled = false;
        _isOnTween = true;
    }

    private void FixedUpdate()
    {
        if(_isOnTween)
            TweenMove();
    }

    private void TweenMove()
    {
        var offsetY = (_tweenEnd.y - transform.position.y) * tweenScale;
        transform.Translate(Vector3.up * offsetY, Space.World);
        if (Vector3.Distance(transform.position, _tweenEnd) <= tweenStopDistance)
        {
            _isOnTween = false;
        }
    }

    public bool Throw()
    {
        if(_isOnTween)
            return false;
        rb.bodyType = RigidbodyType2D.Dynamic;
        knifeCollider.enabled = true;
        rb.AddForce(transform.up * throwForce, ForceMode2D.Impulse);
        return true;
    }
    
    private void CollideWithKnife(Collider2D collider)
    {
        rb.velocity = Vector2.zero;
        gameObject.layer = LayerMask.NameToLayer("FallKnife");
                
        var collPos = collider.transform.position;
        if (collPos.x - transform.position.x < - 0.1f )
            collPos.x -= 1;
        else if (collPos.x - transform.position.x > 0.1f )
            collPos.x += 1;
                
        var direction = (new Vector3(collPos.x, collPos.y, 0) - transform.position).normalized;
        rb.AddForce(-direction * fallForce, ForceMode2D.Impulse);
        rb.AddTorque(torqueForce, ForceMode2D.Force);
    }

    private void AttackToLog(Collider2D collider)
    {
        rb.velocity = Vector2.zero;
        _isAttachedToLog = true; 
        transform.Translate(new Vector3(0, knifeInLogDisplacement, 0), Space.World);
        transform.SetParent(collider.transform);
        rb.bodyType = RigidbodyType2D.Kinematic;
    }
    
    /// <summary>
    /// Проверка столкновения с ножом, который вокнут в бревно
    /// /// Проверка столкновения с бревном
    /// </summary>
    /// <param name="collider"></param>
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Knife"))
        {
            if (collider.GetComponent<Knife>()._isAttachedToLog && !_isAttachedToLog)
            {
                CollideWithKnife(collider);
            }
        }
        else if (collider.CompareTag("Log"))
        {
            AttackToLog(collider);
        }
    }

    /// <summary>
    /// Проверка вылета ножа за границу карты
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Border") && knifeCollider.enabled)
        {
            Destroy(gameObject);
        }
    }
}
