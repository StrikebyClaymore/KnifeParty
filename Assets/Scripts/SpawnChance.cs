using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SpawnChanceConfig", menuName = "SpawnChance", order = 51)]
public class SpawnChance : ScriptableObject
{
    public int apple_chance;
    public int knife_chance;
}