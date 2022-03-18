using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    protected int Hp;
    
    public virtual void SetHp(int hp)
    {
        Hp = hp;
    }
    
    public virtual void GetHit(GameObject knife)
    {
        Hp = Mathf.Max(0, Hp - 1);
        
        HitEffect();
        
        if (Hp == 0)
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

        DestroyEffect();
        
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

     protected virtual void DestroyEffect() { }
     
    private void HitEffect()
    {
        GameManager.LevelManager.hitEffect.Play();
    }
}
