using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : Target
{
    [SerializeField] protected int maxHp;
    [SerializeField] protected KnifeConfig knifeConfig;
    
    public override int SetHp(int hp)
    {
        Hp = maxHp;
        return maxHp;
    }
    
    protected override IEnumerator DestroySelf(GameObject knife)
    {
        GameManager.RootController.chooseKnifeController.knivesGroup.UnlockSlot(knifeConfig);
        yield return StartCoroutine(base.DestroySelf(knife));
    }
    
    protected override void DestroyEffect()
    {
        GameManager.LevelManager.bossExplosionEffect.Play();
    }
}
