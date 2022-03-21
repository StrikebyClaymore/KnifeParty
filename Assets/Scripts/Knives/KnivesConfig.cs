using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "KnivesConfig", menuName = "KnivesConfig", order = 51)]
public class KnivesConfig : ScriptableObject
{
    public KnifeConfig[] knives;
}
