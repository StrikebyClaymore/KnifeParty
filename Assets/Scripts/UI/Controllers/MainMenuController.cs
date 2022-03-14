using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuController : SubController<MainMenuView>
{
    public override void Activate()
    {
        ui.OnPlayClicked += StartGame;
        base.Activate();
    }
    
    public override void Deactivate()
    {
        base.Deactivate();
        ui.OnPlayClicked -= StartGame;
    }
    
    private void StartGame()
    {
        root.ChangeController(RootController.ControllerTypeEnum.Game);
    }
}
