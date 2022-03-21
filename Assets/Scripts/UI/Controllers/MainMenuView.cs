using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class MainMenuView : UIView
{
    [SerializeField] private Button playButton;
    [SerializeField] private Button settingsButton;
    [SerializeField] private Button chooseKnifeButton;

    public UnityAction OnPlayClicked;
    public UnityAction OnSettingsClicked;
    public UnityAction OnChooseKnifeClicked;
    
    private void Awake()
    {
        playButton.onClick.AddListener(PlayClicked);
        settingsButton.onClick.AddListener(SettingsClicked);
        chooseKnifeButton.onClick.AddListener(ChooseKnifeClicked);
    }
    
    private void PlayClicked()
    {
        OnPlayClicked?.Invoke();
    }

    private void SettingsClicked()
    {
        OnSettingsClicked?.Invoke();
    }
    
    private void ChooseKnifeClicked()
    {
        OnChooseKnifeClicked?.Invoke();
    }
}