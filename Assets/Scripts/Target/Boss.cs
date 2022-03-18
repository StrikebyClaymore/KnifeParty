using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : Target
{
    [SerializeField] protected int maxHp;
    
    public override int SetHp(int hp)
    {
        Hp = maxHp;
        return maxHp;
    }

    protected override void DestroyEffect()
    {
        GameManager.LevelManager.bossExplosionEffect.Play();
    }
}
