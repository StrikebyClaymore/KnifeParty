using System.Collections;
using System.Collections.Generic;
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
            GameManager.KnifeId = _currentKnife;
            Save();
        }
    }

    public GameData()
    {
        Load();
        GameManager.RootController.gameController.SetStage(_currentStage);
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
    }

    private void Load()
    {
        MAXStage = PlayerPrefs.GetInt("MAXStage");
        MAXScore = PlayerPrefs.GetInt("MAXScore");
        Apples = PlayerPrefs.GetInt("Apples");
        
        CurrentKnife = PlayerPrefs.GetInt("CurrentKnife");
    }
}
