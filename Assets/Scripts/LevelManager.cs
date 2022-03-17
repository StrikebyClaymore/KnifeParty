using System;
using System.Collections;
using System.Collections.Generic;
using Extensions;
using UnityEngine;
using Random = UnityEngine.Random;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private Transform _objects;
    [SerializeField] public ParticleSystem hitEffect;
    
    [SerializeField] private SpawnChance spawnConfig;

    [SerializeField] private GameObject knifePrefab;
    [SerializeField] private GameObject logPrefab;
    [SerializeField] private GameObject applePrefab;
    
    [SerializeField] private Transform logSpawnPoint;
    [SerializeField] private Transform knifeSpawnPoint;
    
    private const float KnifeSpawnOffsetY = 1.5f;
    private const float AppleSpawnOffsetY = 1.8f;
    
    private GameObject _log;
    private GameObject _currentKnife;

    [SerializeField] private int maxGenerateKnivesCount = 3;
    
    private int _maxKnivesCount = 17;
    private int _knivesCount = 0;
    private int _complexity = 7;

    [SerializeField] private LayerMask spawnLayerMask;

    public void Init()
    {
        GenerateLevel();
        GameManager.Player.enabled = true;
    }

    private void GenerateLevel()
    {
        GenerateLog();

        if (GameManager.GameData.CurrentStage > 1)
        {
            _knivesCount = Mathf.Max(7, _knivesCount + _complexity + Random.Range(-2, 2));   
        }
        else
        {
            _knivesCount += _complexity;
        }

        _knivesCount = Mathf.Min(_knivesCount, _maxKnivesCount);
        
        GameManager.RootController.gameController.FillKnives(_knivesCount);
        _log.GetComponent<Log>().SetHp(_knivesCount);
        _currentKnife = Instantiate(knifePrefab, knifeSpawnPoint.position, knifeSpawnPoint.rotation, _objects);
        _currentKnife.GetComponent<Knife>().Init();
    }

    public void LevelCompleted()
    {
        _complexity++;
        GameManager.GameData.CurrentStage++;
        GameManager.GameData.Save();
        GenerateLevel();
        GameManager.Player.enabled = true;
    }

    public void Restart()
    {
        _complexity = 7;
        _knivesCount = 0;
        _objects.Clear();
        GameManager.GameData.CurrentStage = 1;
        GameManager.GameData.CurrentScore = 0;
        GameManager.RootController.ChangeController(RootController.ControllerTypeEnum.Game);
    }

    public void Lose()
    {
        _objects.Clear();
        GameManager.RootController.ChangeController(RootController.ControllerTypeEnum.GameOver);
    }
    
    public void SpawnKnife()
    {
        if (_knivesCount != 0 && _currentKnife.GetComponent<Knife>().Throw())
        {
            _knivesCount = Mathf.Max(0, _knivesCount - 1);
            GameManager.RootController.gameController.MinusKnife(_knivesCount);
            if (_knivesCount == 0)
                return;
            _currentKnife = Instantiate(knifePrefab, knifeSpawnPoint.position, knifeSpawnPoint.rotation, _objects);
            _currentKnife.GetComponent<Knife>().Init();
        }
    }

    private void GenerateLog()
    {
        _log = Instantiate(logPrefab, logSpawnPoint.position, logSpawnPoint.rotation, _objects);
        GenerateApple();
        if (GameManager.GameData.CurrentStage > 1)
            GenerateKnives();
    }

    private void GenerateApple()
    {
        if (Random.Range(0, 100) > spawnConfig.apple_chance)
            return;
        var rotation = GenerateSpawnRotation();
        var direction = rotation * Vector3.up;
        var spawnPosition = _log.transform.position + direction * AppleSpawnOffsetY;
        var apple = Instantiate(applePrefab, spawnPosition, rotation, _log.transform);
    }

    private void GenerateKnives()
    {
        var dice = Random.Range(1, maxGenerateKnivesCount + 1);
        for (int i = 0; i < dice; i++)
        {
            var rotation = GenerateSpawnRotation();
            var direction = rotation * Vector3.up;
            var spawnPosition = _log.transform.position + direction * KnifeSpawnOffsetY;
            var knife = Instantiate(knifePrefab, spawnPosition, rotation);
            knife.transform.Rotate(0, 0, 180);
            knife.transform.SetParent(_log.transform);
            knife.GetComponent<Knife>().SpawnInLog();
            _knivesCount -= (i % 2);
        }
    }

    private Quaternion GenerateSpawnRotation()
    {
        Quaternion ang;
        Vector3 dir;
        float dist = 2.0f;
        Vector3 pos = _log.transform.position;
        List<Quaternion> angles = new List<Quaternion>();
        
        for (int i = 0; i < 18; i++)
        {
            ang = Quaternion.Euler(0, 0, (float)i * 20f);
            dir = ang * Vector3.up;

            var hit = Physics2D.Raycast(pos, dir, dist, spawnLayerMask);

            if(hit.collider != null)
            {
                //Debug.DrawLine(pos, pos + dir * hit.distance, Color.red, 5f);
            }
            else
            {
                //Debug.DrawLine(pos, pos + dir * dist, Color.green, 5f);
                angles.Add(ang);
            }
        }

        
        if(angles.Count == 0)
            return Quaternion.Euler(Vector3.zero);
        
        int dice = (int)Random.Range(0, angles.Count);
        //dir = angles[dice] * Vector3.up;
        //Debug.DrawLine(pos, pos + dir * (dist * 2f), Color.blue, 5f);

        return angles[dice];
    }
}
