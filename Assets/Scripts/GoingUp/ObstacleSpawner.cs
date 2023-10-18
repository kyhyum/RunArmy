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


    private void Awake()
    {
        _pooler = new ObstaclePooler(spawnInitAmount, transforms, waveDatas);
    }

}
