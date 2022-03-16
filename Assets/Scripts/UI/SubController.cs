using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public abstract class SubController : MonoBehaviour
{
    [SerializeField] protected Text stage;
    [SerializeField] protected Text score;
    [SerializeField] protected Text apples;
    
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
    
    public virtual void SetScore(int count)
    {
        score.text = $"Knives: {count}";
    }
                            
    public virtual void SetApples(int count)
    {
        apples.text = $"Apples: {count}";
    }
    
    public virtual void SetStage(int count)
    { 
        stage.text = $"Stage: {count}";
    }

    /*protected void UpdateGUI()
    { 
        stage.text = $"Stage: {GameManager.GameData.MAXStage}";
        score.text = $"Score: {GameManager.GameData.MAXScore}";
        apples.text = $"Apples: {GameManager.GameData.Apples}";
    }*/

    protected void SetGUIText(int stageCount, int scoreCount, int applesCount)
    { 
        stage.text = $"Stage: {stageCount}";
        score.text = $"Score: {scoreCount}";
        apples.text = $"Apples: {applesCount}";
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