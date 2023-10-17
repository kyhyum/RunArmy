using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private WaveData waveData;

    [Header("Spawn")]
    [SerializeField] private int spawnInitAmount = 10;
    private Queue<Obstacle> obstacleQueue = new Queue<Obstacle>();


    private void Awake()
    {
        
    }

}
