using System.Collections;
using System.Collections.Generic;
using Extensions;
using UnityEngine;
using UnityEngine.UI;

public class GameController : SubController<GameView>
{
    [SerializeField] private Transform knives;
    [SerializeField] private GameObject knifeIconPrefab;

    [SerializeField] private Text score;
    [SerializeField] private Text apples;
    
    public override void Activate()
    {
        base.Activate();
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

    public void SetKnives(int count)
    {
        score.text = $"Knives: {count}";
    }
    
    public void SetApples(int count)
    {
        apples.text = $"Apples: {count}";
    }
    }