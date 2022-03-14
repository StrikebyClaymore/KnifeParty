using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData
{
    private int _maxStage;
    private int _currentStage;
    public int CurrentStage
    {
        get => _currentStage;
        set => _currentStage = value;
    }
    
    private int _maxScore;
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
        PlayerPrefs.SetInt("MAXStage", _maxStage);
        PlayerPrefs.SetInt("MAXScore", _maxScore);
        PlayerPrefs.SetInt("Apples", Apples);
    }

    private void Load()
    {
        _maxStage = PlayerPrefs.GetInt("MAXStage");
        _maxScore = PlayerPrefs.GetInt("MAXScore");
        Apples = PlayerPrefs.GetInt("Apples");
    }
}
