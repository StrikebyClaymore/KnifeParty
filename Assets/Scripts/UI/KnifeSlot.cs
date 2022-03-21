using UnityEngine;
using UnityEngine.UI;

public class KnifeSlot : MonoBehaviour
{
    [SerializeField] private Material closedMaterial;
    [SerializeField] private Material openMaterial;

    [SerializeField] private bool isOpen;
    [SerializeField] private Color closedColor;
    [SerializeField] private Color openColor;

    [SerializeField] public Image image;
    [SerializeField] public Image knifeImage;

    public void Unlock()
    {
        isOpen = true;
        image.color = openColor;
        knifeImage.material = openMaterial;
    }
}
