using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverController : SubController<GameOverView>
{
    public override void Activate()
    {
        ui.OnRestartClicked += RestartGame;
        base.Activate();
    }
    
    public override void Deactivate()
    {
        base.Deactivate();
        ui.OnRestartClicked -= RestartGame;
    }
    
    private void RestartGame()
    {
        GameManager.LevelManager.Restart();
    }
}