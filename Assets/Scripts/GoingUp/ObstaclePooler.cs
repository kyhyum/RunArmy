using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclePooler : ObjectPoolerBase<Obstacle>
{
    private Transform[] _transforms;

    private Dictionary<Wave, WaveData> _dataDict = new Dictionary<Wave, WaveData>();
    private Dictionary<Wave, Queue<Obstacle>> _waveDict = new Dictionary<Wave, Queue<Obstacle>>();

    public ObstaclePooler(int spawnInitAmount, Transform[] transforms, WaveData[] waveDatas) : base(spawnInitAmount)
    {
        _transforms = new Transform[transforms.Length];
        _transforms = transforms;
        
        foreach (var data in waveDatas)
        {
            _dataDict.Add(data.Wave, data);
            _waveDict.Add(data.Wave, new Queue<Obstacle>());

            int routeCount = (int)data.SpawnDelayTime;
            routeCount = routeCount < 1 ? 1 : routeCount;

            for (int i = 0; i < routeCount; i++)
            {
                for (int j = 0; j < data.Obstacles.Length; j++)
                {
                    Obstacle obstacle;
                    if (i != 0)
                        obstacle = CreateNewObject(data);
                    else
                        obstacle = CreateNewObject(data, j);

                    Push(obstacle);
                }
            }
        }
    }

    private Obstacle CreateNewObject(WaveData data, int index = -1)
    {
        if (index == -1)
            index = UnityEngine.Random.Range(0, data.Obstacles.Length);

        Obstacle obstacle = UnityEngine.Object.Instantiate(data.Obstacles[index], _transforms[(int)data.Wave]);
        obstacle.Init(Push);
        _waveDict[data.Wave].Enqueue(obstacle);
        return obstacle;
    }

    public Obstacle Pool(Wave wave)
    {
        Obstacle obstacle = null;

        if (_waveDict[wave].Count > 0)
        {
            obstacle = _waveDict[wave].Dequeue();
        }
        else
        {
            obstacle = CreateNewObject(_dataDict[wave]);
        }

        obstacle.transform.position = _transforms[(int)wave].position;
        obstacle.gameObject.SetActive(true);

        return obstacle;
    }

    private void Push(Obstacle obstacle)
    {
        obstacle.gameObject.SetActive(false);
    }
}
