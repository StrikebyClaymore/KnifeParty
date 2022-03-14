using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuController : SubController<MainMenuView>
{
    [SerializeField] private Text stage;
    [SerializeField] private Text score;
    [SerializeField] private Text apples;
    
    public override void Activate()
    {
        ui.OnPlayClicked += StartGame;
        base.Activate();
        SetStageScore();
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

    private void SetStageScore()
    {
        stage.text = $"Stage: {GameManager.GameData.MAXStage}";
        score.text = $"Score: {GameManager.GameData.MAXScore}";
        apples.text = $"Apples: {GameManager.GameData.Apples}";
    }
}
