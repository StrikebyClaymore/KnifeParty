using UnityEngine;

public class KnivesManager : MonoBehaviour
{
    public KnivesConfig knivesConfig;
    public int knifeId;
    
    public KnifeConfig GetKnifeConfig()
    {
        return knivesConfig.knives[knifeId];
    }
}