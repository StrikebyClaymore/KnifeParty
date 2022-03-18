using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossWithPhase : Boss
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite phaseTwoSprite;
    private int _maxHp;
    private float _phaseTwoHp = 0.5f;

    public override void SetHp(int hp)
    {
        _maxHp = hp;
        Hp = _maxHp;
    }
    
    public override void GetHit(GameObject knife)
    {
        base.GetHit(knife);
        if (Hp <= _maxHp * _phaseTwoHp)
        {
            spriteRenderer.sprite = phaseTwoSprite;
        }
    }

}
