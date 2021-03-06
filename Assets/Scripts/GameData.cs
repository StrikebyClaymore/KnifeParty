using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameData
{
    public int MAXStage;
    private int _currentStage = 1;
    public int CurrentStage
    {
        get => _currentStage;
        set
        {
            _currentStage = value;
            GameManager.RootController.gameController.SetStage(_currentStage);
            Save();
        }
    }
    
    public int MAXScore;
    private int _currentScore;
    public int CurrentScore
    {
        get => _currentScore;
        set
        {
            _currentScore = value;
            GameManager.RootController.gameController.SetScore(_currentScore);
            Save();
        } 
    }
    
    private int _apples;
    public int Apples
    {
        get => _apples;
        set
        {
            _apples = value;
            GameManager.RootController.gameController.SetApples(_apples);
            Save();
        } 
    }

    private int _currentKnife;
    public int CurrentKnife
    {
        get => _currentKnife;
        set
        {
            _currentKnife = value;
            GameManager.KnivesManager.knifeId = _currentKnife;
            Save();
        }
    }

    public HashSet<int> UnlockedKnives = new HashSet<int>{ 0 };

    public GameData()
    {
        Load();
    }

    public void Save()
    {
        if (_currentScore > MAXScore)
            MAXScore = _currentScore;
        if (_currentStage > MAXStage)
            MAXStage = _currentStage;
                
        PlayerPrefs.SetInt("MAXStage", MAXStage);
        PlayerPrefs.SetInt("MAXScore", MAXScore);
        PlayerPrefs.SetInt("Apples", Apples);

        PlayerPrefs.SetInt("CurrentKnife", CurrentKnife);

        var knivesString = "";
        foreach (var id in UnlockedKnives)
            knivesString += id + ",";

        PlayerPrefs.SetString("Knives", knivesString);
    }

    private void Load()
    {
        var knivesString = PlayerPrefs.GetString("Knives");
        var knives = knivesString.Split(',');
        
        foreach (var strId in knives)
        {
            if (int.TryParse(strId, out var id))
            {
                UnlockedKnives.Add(id);
                GameManager.KnivesManager.knivesConfig.knives[id].unlocked = true;
            }
        }
        
        MAXStage = PlayerPrefs.GetInt("MAXStage");
        MAXScore = PlayerPrefs.GetInt("MAXScore");
        _apples = PlayerPrefs.GetInt("Apples");
        
        CurrentKnife = PlayerPrefs.GetInt("CurrentKnife");
        GameManager.KnivesManager.knifeId = _currentKnife;
    }
    
    public void SaveUnlockedKnife(int id)
    {
        UnlockedKnives.Add(id);
        Save();
    }
}
