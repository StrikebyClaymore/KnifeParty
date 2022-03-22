using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class SettingsView : UIView
{
    [SerializeField] private Button vibrationsButton;
    [SerializeField] private Color onColor;
    [SerializeField] private Color offColor; 

    [SerializeField] private Button backButton;

    public UnityAction OnVibrationsClicked;
    public UnityAction OnBackClicked;
    
    private void Awake()
    {
        vibrationsButton.onClick.AddListener(VibrationsClicked);
        backButton.onClick.AddListener(BackClicked);
    }

    private void VibrationsClicked()
    {
        var image = vibrationsButton.GetComponent<Image>();
        var color = image.color;
        color = color == offColor ? onColor : offColor;
        image.color = color;
        
        OnVibrationsClicked?.Invoke();
    }
    
    private void BackClicked()
    {
        OnBackClicked?.Invoke();
    }
}