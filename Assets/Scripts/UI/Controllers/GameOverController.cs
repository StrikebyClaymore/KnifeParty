using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverController : ScoreController<GameOverView>
{
    public override void Activate()
    {
        ui.OnRestartClicked += RestartGame;
        base.Activate();
        SetGUIText(GameManager.GameData.CurrentStage, GameManager.GameData.CurrentScore, GameManager.GameData.Apples);
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