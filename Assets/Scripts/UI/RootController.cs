using UnityEngine;

public class RootController : MonoBehaviour
{
    public enum ControllerTypeEnum
    {
        MainMenu,
        Game,
        GameOver
    }

    [Header("Controllers")]
    [SerializeField]
    public MainMenuController menuController;
    [SerializeField]
    public GameController gameController;
    [SerializeField]
    public GameOverController gameOverController;

    private void Start()
    {
        menuController.root = this;
        gameController.root = this;
        gameOverController.root = this;
        ChangeController(ControllerTypeEnum.MainMenu);
    }
    
    public void ChangeController(ControllerTypeEnum controller)
    {
        DeactivateControllers();
        
        switch (controller)
        {
            case ControllerTypeEnum.MainMenu:
                menuController.Activate();
                break;
            case ControllerTypeEnum.Game:
                gameController.Activate();
                break;
            case ControllerTypeEnum.GameOver:
                gameOverController.Activate();
                break;
            default:
                break;
        }
    }
    
    public void DeactivateControllers()
    {
        menuController.Deactivate();
        gameController.Deactivate();
        gameOverController.Deactivate();
    }
}