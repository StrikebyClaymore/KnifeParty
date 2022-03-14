﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData
{
    public int MAXScore;
    public int Apples;

    public GameData()
    {
        Load();
    }

    public void Save()
    {
        PlayerPrefs.SetInt("MAXScore", MAXScore);
        PlayerPrefs.SetInt("Apples", Apples);
    }

    private void Load()
    {
        MAXScore = PlayerPrefs.GetInt("MAXScore");
        Apples = PlayerPrefs.GetInt("Apples");
    }
}
