using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "KnifeConfig", menuName = "KnifeConfig", order = 51)]
public class KnifeConfig : ScriptableObject
{
    public Sprite sprite;
    public bool unlocked;
    public int id;
}
