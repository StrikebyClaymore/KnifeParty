using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KnivesGroup : MonoBehaviour
{
    [SerializeField] private KnivesConfig knivesConfig;
    [SerializeField] private Image currentKnife;

    private void Awake()
    {
        ConnectSlotsButtons();

        currentKnife.sprite = GameManager.KnivesManager.GetKnifeConfig().sprite;
    }

    private void ConnectSlotsButtons()
    {
        for (int i = 0; i < knivesConfig.knives.Length; i++)
        {
            var knife = knivesConfig.knives[i];
            knife.id = i;
            
            var idx = knife.id;
    
            var row = transform.GetChild(idx / 4);
            var child = row.GetChild(idx % 4);
            var button = child.GetComponent<Button>();
            var slot = child.GetComponent<KnifeSlot>();
        
            slot.knifeImage.enabled = true;
            slot.knifeImage.sprite = knife.sprite;
        
            if(!knife.unlocked)
                continue;
        
            slot.Unlock();
    
            button.enabled = true;
            button.onClick.AddListener(delegate { KnifeSlotOnClicked(idx); });
            
        }
    }

    public void UnlockSlot(KnifeConfig knife)
    {
        if(knife.unlocked)
            return;
        
        knife.unlocked = true;

        var idx = knife.id;

        GameManager.GameData.SaveUnlockedKnife(idx);

        var row = transform.GetChild(idx / 4);
        var child = row.GetChild(idx % 4);
        var button = child.GetComponent<Button>();
        var slot = child.GetComponent<KnifeSlot>();

        slot.Unlock();
        
        button.enabled = true;
        button.onClick.AddListener(delegate { KnifeSlotOnClicked(idx); });
    }
    
    private void KnifeSlotOnClicked(int idx)
    {
        var row = transform.GetChild(idx / 4);
        var slot = row.GetChild(idx % 4).GetComponent<KnifeSlot>();
        currentKnife.sprite = slot.knifeImage.sprite;
        GameManager.GameData.CurrentKnife = idx;
    }
}
