using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData
{
    public int MAXStage;
    private int _currentStage;
    public int CurrentStage
    {
        get => _currentStage;
        set => _currentStage = value;
    }
    
    public int MAXScore;
    private int _currentScore;
    public int CurrentScore
    {
        get => _currentScore;
        set
        {
            _currentScore = value;
            GameManager.RootController.gameController.SetKnives(_currentScore);
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
        } 
    }
    
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
    }

    private void Load()
    {
        MAXStage = PlayerPrefs.GetInt("MAXStage");
        MAXScore = PlayerPrefs.GetInt("MAXScore");
        Apples = PlayerPrefs.GetInt("Apples");
    }
}
