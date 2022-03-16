using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static RootController RootController;
    public static PlayerController Player;
    public static LevelManager LevelManager;
    public static GameData GameData;

    private void Awake()
    {
        RootController = GetComponentInChildren<RootController>();
        GameData = new GameData();
        Player = GetComponentInChildren<PlayerController>();
        LevelManager = GetComponentInChildren<LevelManager>();
        Vibration.Init();
    }
    
}
