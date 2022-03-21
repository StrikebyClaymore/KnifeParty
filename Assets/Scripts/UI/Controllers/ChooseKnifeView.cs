using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ChooseKnifeView : UIView
{
    [SerializeField] private Button backButton;
    
    public UnityAction OnBackClicked;
    
    private void Awake()
    {
        backButton.onClick.AddListener(BackClicked);
    }

    private void BackClicked()
    {
        OnBackClicked?.Invoke();
    }
}
