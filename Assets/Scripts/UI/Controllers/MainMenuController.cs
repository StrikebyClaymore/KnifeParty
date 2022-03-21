using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuController : ScoreController<MainMenuView>
{
    public override void Activate()
    {
        ui.OnPlayClicked += StartGame;
        ui.OnSettingsClicked += OpenSettings;
        ui.OnChooseKnifeClicked += OpenChooseKnife;
        base.Activate();
        SetGUIText(GameManager.GameData.MAXStage, GameManager.GameData.MAXScore, GameManager.GameData.Apples);
    }
    
    public override void Deactivate()
    {
        base.Deactivate();
        ui.OnPlayClicked -= StartGame;
        ui.OnSettingsClicked -= OpenSettings;
        ui.OnChooseKnifeClicked -= OpenChooseKnife;
    }
    
    private void StartGame()
    {
        root.ChangeController(RootController.ControllerTypeEnum.Game);
    }

    private void OpenSettings()
    {
        root.ChangeController(RootController.ControllerTypeEnum.Settings);
    }
    
    public override void SetScore(int count)
    { 
        score.text = $"Score {count}";
    }
    
    private void OpenChooseKnife()
    {
        root.ChangeController(RootController.ControllerTypeEnum.ChooseKnife);
    }
}
