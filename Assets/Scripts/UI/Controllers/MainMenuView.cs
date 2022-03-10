using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class MainMenuView : UIView
{
    [SerializeField] private Button playButton;

    public UnityAction OnPlayClicked;

    private void Awake()
    {
        playButton.onClick.AddListener(PlayClicked);
    }
    
    private void PlayClicked()
    {
        OnPlayClicked?.Invoke();
    }
}