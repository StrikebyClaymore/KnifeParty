using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public abstract class SubController : MonoBehaviour
{
    [HideInInspector]
    public RootController root;

    public virtual void Activate()
    {
        gameObject.SetActive(true);
    }
    
    public virtual void Deactivate()
    {
        gameObject.SetActive(false);
    }
}

public abstract class SubController<T> : SubController where T : UIView
{
    [SerializeField]
    protected T ui;
    public T UI => ui;
    
    public override void Activate()
    {
        base.Activate();
        ui.Show();
    }
    
    public override void Deactivate()
    {
        base.Deactivate();
        ui.Hide();
    }
}