using UnityEngine;

public class SettingsController : SubController<SettingsView>
{
    public override void Activate()
    {
        ui.OnVibrationsClicked += SetVibrations;
        ui.OnBackClicked += ReturnBack;
        base.Activate();
    }
    
    public override void Deactivate()
    {
        base.Deactivate();
        ui.OnVibrationsClicked -= SetVibrations;
        ui.OnBackClicked -= ReturnBack;
    }
    
    private void SetVibrations()
    {
        GameManager.VibrationsOn = !GameManager.VibrationsOn;
    }

    private void ReturnBack()
    {
        GameManager.RootController.ReturnToPrevious();
    }
}