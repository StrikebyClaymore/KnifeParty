using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverController : ScoreController<GameOverView>
{
    public override void Activate()
    {
        ui.OnRestartClicked += RestartGame;
        ui.OnBackClicked += ReturnBack;
        ui.OnSettingsClicked += OpenSettings;
        ui.OnChooseKnifeClicked += OpenChooseKnife;
        base.Activate();
        SetGUIText(GameManager.GameData.CurrentStage, GameManager.GameData.CurrentScore, GameManager.GameData.Apples);
    }
    
    public override void Deactivate()
    {
        base.Deactivate();
        ui.OnRestartClicked -= RestartGame;
        ui.OnBackClicked -= ReturnBack;
        ui.OnSettingsClicked -= OpenSettings;
        ui.OnChooseKnifeClicked -= OpenChooseKnife;
    }
    
    private void RestartGame()
    {
        GameManager.LevelManager.Restart();
    }
    
    private void ReturnBack()
    {
        root.ChangeController(RootController.ControllerTypeEnum.MainMenu);
    }
    
    private void OpenSettings()
    {
        root.ChangeController(RootController.ControllerTypeEnum.Settings);
    }

    private void OpenChooseKnife()
    {
        root.ChangeController(RootController.ControllerTypeEnum.ChooseKnife);
    }
}