using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static PlayerController Player;

    private void Awake()
    {
        Player = GetComponent<PlayerController>();
    }
}
