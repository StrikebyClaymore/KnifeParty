using System;
using UnityEngine;
using UnityEngine.UI;

public class Knife : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Collider2D knifeCollider;
    [SerializeField] private SpriteRenderer spriteRenderer;
    
    [SerializeField] private float throwForce = 30f;
    [SerializeField] private float fallForce = 20f;
    [SerializeField] private float torqueForce = 720f;
    [SerializeField] private float knifeInLogDisplacement = 0.6f;
    private bool _isAttachedToLog;
    
    [Header("Tween params")]
    private Vector3 _tweenStart;
    private Vector3 _tweenEnd;
    [SerializeField] private float tweenOffsetY = 2.5f;
    [SerializeField] private float tweenScale = 0.3f;
    [SerializeField] private float tweenStopDistance = 0.2f;
    private float _tweenPositionY;
    private bool _isOnTween;

    public void Init(Sprite sprite = null)
    {
        if (!(sprite is null))
            spriteRenderer.sprite = sprite;
        
        _tweenStart = transform.position;
        _tweenEnd = new Vector3(0, _tweenStart.y + tweenOffsetY, 0);
        rb.bodyType = RigidbodyType2D.Kinematic;
        knifeCollider.enabled = false;
        _isOnTween = true;
    }

    public void SpawnInLog()
    {
        _isAttachedToLog = true;
        rb.bodyType = RigidbodyType2D.Kinematic;
    }
    
    private void Update()
    {
        if (_isOnTween)
        {
            _tweenPositionY = (_tweenEnd.y - transform.position.y) * tweenScale;
            var displacement = Vector3.up * (_tweenPositionY * Time.deltaTime);
            if (Vector3.Distance(transform.position + displacement, _tweenEnd) <= tweenStopDistance)
            {
                _isOnTween = false;
                transform.position = _tweenEnd;
            }
        }
    }

    private void FixedUpdate()
    {
        if(_isOnTween)
            TweenMove();
    }

    private void TweenMove()
    {
        transform.Translate(Vector3.up * _tweenPositionY, Space.World);
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
        gameObject.layer = LayerMask.NameToLayer("FallObject");
                
        var collPos = collider.transform.position;
        if (collPos.x - transform.position.x < - 0.1f )
            collPos.x -= 1;
        else if (collPos.x - transform.position.x > 0.1f )
            collPos.x += 1;
                
        var direction = (new Vector3(collPos.x, collPos.y, 0) - transform.position).normalized;
        rb.AddForce(-direction * fallForce, ForceMode2D.Impulse);
        rb.AddTorque(torqueForce, ForceMode2D.Force);
        
        // Сначала обрабатывается столкновение с ножом даже если его коллизия находится дальше дерева
        // Поэтому откладываем вызов метода пока не обработается столкновение с деревом
        Invoke(nameof(CheckLose), 0.1f);
    }

    private void CheckLose()
    {
        if (!_isAttachedToLog)
        {
            GameManager.Vibrate();
            GameManager.Player.enabled = false;
            GameManager.LevelManager.Invoke(nameof(GameManager.LevelManager.Lose), 0.5f);
        }
    }
    
    private void AttachToLog(Collider2D collider)
    {
        _isAttachedToLog = true;
        rb.velocity = Vector2.zero;
        rb.bodyType = RigidbodyType2D.Kinematic;
        transform.SetParent(collider.transform);
        transform.Translate(new Vector3(0, knifeInLogDisplacement, 0), Space.World);
        GameManager.GameData.CurrentScore++;
        collider.gameObject.GetComponent<Target>().GetHit(gameObject);
        
        //GameManager.Vibrate();
    }

    /// <summary>
    /// Проверка столкновений
    /// </summary>
    /// <param name="collider"></param>
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Log"))
        {
            if (!_isAttachedToLog)
                AttachToLog(collider);
        }
        else if (collider.CompareTag("Knife"))
        {
            if (collider.GetComponent<Knife>()._isAttachedToLog && !_isAttachedToLog)
            {
                CollideWithKnife(collider);
            }
        }

        if (collider.CompareTag("Apple"))
        {
            if (!_isAttachedToLog)
                collider.GetComponent<Apple>().GetHit();
        }
    }
}
