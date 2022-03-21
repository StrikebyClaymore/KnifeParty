using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GameOverView : UIView
{
    [SerializeField] private Button restartButton;
    [SerializeField] private Button backButton;
    [SerializeField] private Button settingsButton;
    [SerializeField] private Button chooseKnifeButton;
    
    public UnityAction OnRestartClicked;
    public UnityAction OnBackClicked;
    public UnityAction OnSettingsClicked;
    public UnityAction OnChooseKnifeClicked;

    private void Awake()
    {
        restartButton.onClick.AddListener(RestartClicked);
        backButton.onClick.AddListener(BackClicked);
        settingsButton.onClick.AddListener(SettingsClicked);
        chooseKnifeButton.onClick.AddListener(ChooseKnifeClicked);
    }
    
    private void RestartClicked()
    {
        OnRestartClicked?.Invoke();
    }
    
    private void BackClicked()
    {
        OnBackClicked?.Invoke();
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
