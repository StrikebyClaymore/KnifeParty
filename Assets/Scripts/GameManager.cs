using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static PlayerController Player;
    public static LevelManager LevelManager;
    public static GameData GameData = new GameData();

    private void Awake()
    {
        Player = GetComponent<PlayerController>();
        LevelManager = GetComponent<LevelManager>();
    }
    
}
