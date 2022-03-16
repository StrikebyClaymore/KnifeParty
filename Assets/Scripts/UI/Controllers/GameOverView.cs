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

    public UnityAction OnRestartClicked;
    public UnityAction OnBackClicked;
    public UnityAction OnSettingsClicked;

    private void Awake()
    {
        restartButton.onClick.AddListener(RestartClicked);
        backButton.onClick.AddListener(BackClicked);
        settingsButton.onClick.AddListener(SettingsClicked);
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
}
