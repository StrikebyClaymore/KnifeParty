using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GameOverView : UIView
{
    [SerializeField] private Button restartButton;

    public UnityAction OnRestartClicked;

    private void Awake()
    {
        restartButton.onClick.AddListener(RestartClicked);
    }
    
    private void RestartClicked()
    {
        OnRestartClicked?.Invoke();
    }
}
