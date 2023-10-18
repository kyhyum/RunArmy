using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private WaveData[] waveDatas;

    [Header("Spawn")]
    [SerializeField] private int spawnInitAmount = 10;
    [SerializeField] private Transform[] transforms;
    private ObstaclePooler _pooler;
    private SpawnTimeCalculator _calculator;

    [Header("Shoot")]
    [SerializeField] private float minPower = 1f;
    [SerializeField] private float maxPower = 2f;
    [SerializeField] private float absAngle = 30f;
    private ObstacleShooter _shooter;
    private CharacterController _target;
    

    private void Awake()
    {
        _pooler = new ObstaclePooler(spawnInitAmount, transforms, waveDatas);
        _calculator = new SpawnTimeCalculator(waveDatas, Spawn);
        _target = FindAnyObjectByType<CharacterController>();
        _shooter = new ObstacleShooter(_target.transform, minPower, maxPower, absAngle);
    }

    private void Update()
    {
        _calculator.Calculate();
    }

    private void Spawn(Wave wave)
    {
        Obstacle obstacle = _pooler.Pool(wave);
        _shooter.Shoot(obstacle);
    }
}
