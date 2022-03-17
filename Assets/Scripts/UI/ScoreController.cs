using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public abstract class ScoreController : SubController
{
    [SerializeField] protected Text stage;
    [SerializeField] protected Text score;
    [SerializeField] protected Text apples;

    public virtual void SetStage(int count)
    { 
        stage.text = $"Stage {count}";
    }
    
    public virtual void SetScore(int count)
    {
        score.text = $"{count}";
    }
                            
    public virtual void SetApples(int count)
    {
        apples.text = $"{count}";
    }
    
    protected void SetGUIText(int stageCount, int scoreCount, int applesCount)
    {
        SetStage(stageCount);
        SetScore(scoreCount);
        SetApples(applesCount);
    }
}

public abstract class ScoreController<T> : ScoreController where T : UIView
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