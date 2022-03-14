using System;
using System.Collections;
using System.Collections.Generic;
using Extensions;
using UnityEngine;
using Random = UnityEngine.Random;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private Transform _objects;
    
    [SerializeField] private SpawnChance spawnConfig;

    [SerializeField] private GameObject knifePrefab;
    [SerializeField] private GameObject logPrefab;
    [SerializeField] private GameObject applePrefab;
    
    [SerializeField] private Transform logSpawnPoint;
    [SerializeField] private Transform knifeSpawnPoint;
    
    private const float KnifeSpawnOffsetY = 1.222223f-0.1222228f;
    private const float AppleSpawnOffsetY = 1.4f;
    
    private GameObject _log;
    private GameObject _currentKnife;

    [SerializeField] private int maxGenerateKnivesCount = 3;
    
    private int _maxKnivesCount = 7;
    private int _knivesCount = 7;

    public void Init()
    {
        GenerateLevel();
        GameManager.Player.enabled = true;
    }

    private void GenerateLevel()
    {
        _objects.Clear();
        GenerateLog();
        _knivesCount = _maxKnivesCount;
        GameManager.RootController.gameController.FillKnives(_maxKnivesCount);
        _currentKnife = Instantiate(knifePrefab, knifeSpawnPoint.position, knifeSpawnPoint.rotation, _objects);
        _currentKnife.GetComponent<Knife>().Init();
    }

    public void LevelCompleted()
    {
        GameManager.GameData.CurrentStage++;
        GameManager.GameData.Save();
        GenerateLevel();
        Debug.Log("Level completed");
    }

    public void Restart()
    {
        GameManager.RootController.ChangeController(RootController.ControllerTypeEnum.Game);
        Debug.Log("Restart level");
    }

    public void Lose()
    {
        GameManager.RootController.ChangeController(RootController.ControllerTypeEnum.GameOver);
    }
    
    public void SpawnKnife()
    {
        _knivesCount = Mathf.Max(0, _knivesCount - 1);
        
        if (_currentKnife.GetComponent<Knife>().Throw())
        {
            GameManager.RootController.gameController.MinusKnife(_knivesCount);
            _currentKnife = Instantiate(knifePrefab, knifeSpawnPoint.position, knifeSpawnPoint.rotation, _objects);
            _currentKnife.GetComponent<Knife>().Init();
        }
    }

    private void GenerateLog()
    {
        _log = Instantiate(logPrefab, logSpawnPoint.position, logSpawnPoint.rotation, _objects);
        GenerateApple();
        GenerateKnives();
        _log.GetComponent<Log>().SetHp(_knivesCount);
    }

    private void GenerateApple()
    {
        if (Random.Range(0, 100) > spawnConfig.apple_chance)
            return;
        var angle = Random.Range(0, 360);
        var rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        var direction = rotation * Vector3.up;
        var spawnPosition = _log.transform.position + direction * AppleSpawnOffsetY;
        var apple = Instantiate(applePrefab, spawnPosition, rotation, _log.transform);
    }

    private void GenerateKnives()
    {
        for (int i = 0; i < maxGenerateKnivesCount; i++)
        {
            if (Random.Range(0, 100) > spawnConfig.knife_chance)
                return;
            var angle = Random.Range(0, 360);
            var rotation = Quaternion.Euler(new Vector3(0, 0, angle));
            var direction = (rotation * Vector3.up).normalized;
            var spawnPosition = _log.transform.position - direction * KnifeSpawnOffsetY;
            var knife = Instantiate(knifePrefab, spawnPosition, rotation);
            knife.transform.SetParent(_log.transform);
            knife.GetComponent<Knife>().SpawnInLog();
        }
    }
}
