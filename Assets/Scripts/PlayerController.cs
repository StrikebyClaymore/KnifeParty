using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject knifePrefab;
    [SerializeField] private Transform knifeSpawnPoint;

    private GameObject _currentKnife;
    private int knifesCount;
    
    private void Start()
    {
        _currentKnife = Instantiate(knifePrefab,knifeSpawnPoint.position, knifeSpawnPoint.rotation, transform);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            TouchDown();
        }
        
        if (Input.touches.Length > 0)
        {
            var ev = Input.touches[0];
            if (ev.phase == TouchPhase.Began)
                TouchDown();
        }
    }
    
    private void TouchDown()
    {
        SpawnKnife();
    }

    private void SpawnKnife()
    {
        if (_currentKnife.GetComponent<Knife>().Throw())
            _currentKnife = Instantiate(knifePrefab,knifeSpawnPoint.position, knifeSpawnPoint.rotation, transform);
    }
}
