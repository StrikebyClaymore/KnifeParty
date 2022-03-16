using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class SettingsView : UIView
{
    [SerializeField] private Button vibrationsButton;
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
        OnVibrationsClicked?.Invoke();
    }
    
    private void BackClicked()
    {
        OnBackClicked?.Invoke();
    }
}