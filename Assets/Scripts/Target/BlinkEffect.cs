using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkEffect : MonoBehaviour
{
    [SerializeField] private SpriteRenderer blinkSpriteRenderer;

    private void Update()
    {
        var color =  blinkSpriteRenderer.color;
        color.a = Mathf.Max(0, color.a - 0.03f);
        blinkSpriteRenderer.color = color;
       
        if (color.a <= 0)
        {
            gameObject.SetActive(false);
        }
    }

    public void Play()
    {
        blinkSpriteRenderer.color = new Color(1f, 1f, 1f, 0.7f);
        gameObject.SetActive(true);
    }
    
}
