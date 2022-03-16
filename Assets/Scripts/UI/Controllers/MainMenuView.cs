using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class MainMenuView : UIView
{
    [SerializeField] private Button playButton;
    [SerializeField] private Button settingsButton;

    public UnityAction OnPlayClicked;
    public UnityAction OnSettingsClicked;
    
    private void Awake()
    {
        playButton.onClick.AddListener(PlayClicked);
        settingsButton.onClick.AddListener(SettingsClicked);
    }
    
    private void PlayClicked()
    {
        OnPlayClicked?.Invoke();
    }

    private void SettingsClicked()
    {
        OnSettingsClicked?.Invoke();
    }
}