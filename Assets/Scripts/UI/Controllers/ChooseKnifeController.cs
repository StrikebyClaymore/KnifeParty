using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseKnifeController : SubController<ChooseKnifeView>
{
    public KnivesGroup knivesGroup;
    
    public override void Activate()
    {
        ui.OnBackClicked += ReturnBack;
        base.Activate();
    }
    
    public override void Deactivate()
    {
        base.Deactivate();
        ui.OnBackClicked -= ReturnBack;
    }
    
    private void ReturnBack()
    {
        GameManager.RootController.ReturnToPrevious();
    }
}
