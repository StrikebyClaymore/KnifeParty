using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : SubController<GameView>
{
    [SerializeField] private GameObject knives;
    [SerializeField] private GameObject knifeIconPrefab;
    
    public override void Activate()
    {
        base.Activate();
        GameManager.LevelManager.Init();
    }
    
    public override void Deactivate()
    {
        base.Deactivate();
    }

    public void FillKnives(int count)
    {
        foreach (Transform child in knives.transform)
        {
            Destroy(child.gameObject);
        }
        for (int i = 0; i < count; i++)
        {
            Instantiate(knifeIconPrefab, knives.transform);
        }
    }
}