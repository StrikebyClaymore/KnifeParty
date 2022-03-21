using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static RootController RootController;
    public static PlayerController Player;
    public static LevelManager LevelManager;
    public static KnivesManager KnivesManager;
    public static GameData GameData;

    public static bool VibrationsOn = false;

    private void Awake()
    {
        KnivesManager = GetComponent<KnivesManager>();
        GameData = new GameData();
        RootController = GetComponentInChildren<RootController>();
        Player = GetComponentInChildren<PlayerController>();
        LevelManager = GetComponentInChildren<LevelManager>();
        Vibration.Init();
    }

    public static void Vibrate()
    {
        if(VibrationsOn)
            Vibration.Vibrate();
    }
}
