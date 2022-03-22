using System.Collections;
using System.Collections.Generic;
using Extensions;
using UnityEngine;
using UnityEngine.UI;

public class GameController : ScoreController<GameView>
{
    [SerializeField] private Transform knives;
    [SerializeField] private GameObject knifeIconPrefab;

    public override void Activate()
    {
        base.Activate();
        SetApples(GameManager.GameData.Apples);
        GameManager.LevelManager.Init();
    }
    
    public override void Deactivate()
    {
        base.Deactivate();
    }

    public void MinusKnife(int idx)
    {
        knives.GetChild(idx).GetComponent<Image>().color = Color.black;
    }
    
    public void FillKnives(int count)
    {
        knives.Clear();
        for (int i = 0; i < count; i++)
        {
            Instantiate(knifeIconPrefab, knives.transform);
        }
    }

}