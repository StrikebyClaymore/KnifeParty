using UnityEngine;

public class RootController : MonoBehaviour
{
    public enum ControllerTypeEnum
    {
        MainMenu,
        Game,
        GameOver,
        Settings
    }

    [Header("Controllers")]
    [SerializeField]
    public MainMenuController menuController;
    [SerializeField]
    public GameController gameController;
    [SerializeField]
    public GameOverController gameOverController;
    [SerializeField]
    public SettingsController settingsController;

    private ControllerTypeEnum _current;
    private ControllerTypeEnum _previous;
    
    private void Start()
    {
        menuController.root = this;
        gameController.root = this;
        gameOverController.root = this;
        settingsController.root = this;

        _current = ControllerTypeEnum.MainMenu;
        ChangeController(_current);
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
            case ControllerTypeEnum.Settings:
                settingsController.Activate();
                break;
            default:
                break;
        }

        _previous = _current;
        _current = controller;
    }

    public void ReturnToPrevious()
    {
        ChangeController(_previous);
    }
    
    public void DeactivateControllers()
    {
        menuController.Deactivate();
        gameController.Deactivate();
        gameOverController.Deactivate();
        settingsController.Deactivate();
    }
}