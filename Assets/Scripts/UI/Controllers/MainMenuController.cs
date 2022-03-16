using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuController : SubController<MainMenuView>
{
    public override void Activate()
    {
        ui.OnPlayClicked += StartGame;
        ui.OnSettingsClicked += OpenSettings;
        base.Activate();
        SetGUIText(GameManager.GameData.MAXStage, GameManager.GameData.MAXScore, GameManager.GameData.Apples);
    }
    
    public override void Deactivate()
    {
        base.Deactivate();
        ui.OnPlayClicked -= StartGame;
        ui.OnSettingsClicked -= OpenSettings;
    }
    
    private void StartGame()
    {
        root.ChangeController(RootController.ControllerTypeEnum.Game);
    }

    private void OpenSettings()
    {
        root.ChangeController(RootController.ControllerTypeEnum.Settings);
    }
}
