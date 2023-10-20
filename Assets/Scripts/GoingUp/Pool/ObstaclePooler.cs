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

            int routeCount = (int)(spawnInitAmount / data.SpawnDelayTime);
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

        Transform parent = _transforms[(int)data.Wave];
        Obstacle obstacle = UnityEngine.Object.Instantiate(data.Obstacles[index], parent);

        obstacle.SetWave(data.Wave);
        obstacle.Init(Push);

        Vector3 offsetScale = new Vector3(
            obstacle.transform.localScale.x / parent.transform.localScale.x,
            obstacle.transform.localScale.y / parent.transform.localScale.y,
            obstacle.transform.localScale.z / parent.transform.localScale.z
            );

        obstacle.transform.localScale = offsetScale;
        return obstacle;
    }

    public Obstacle Pool(Wave wave)
    {
        Obstacle obstacle;

        if (_waveDict[wave].Count > 0)
        {
            obstacle = _waveDict[wave].Dequeue();
        }
        else
        {
            obstacle = CreateNewObject(_dataDict[wave]);
        }

        obstacle.transform.SetPositionAndRotation(_transforms[(int)wave].position, Quaternion.identity);
        obstacle.gameObject.SetActive(true);

        return obstacle;
    }

    private void Push(Obstacle obstacle)
    {
        obstacle.gameObject.SetActive(false);
        _waveDict[obstacle.Wave].Enqueue(obstacle);
    }
}
