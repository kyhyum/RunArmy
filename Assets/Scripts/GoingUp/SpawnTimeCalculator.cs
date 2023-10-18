using System;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTimeCalculator
{
    private Dictionary<Wave, float> _waveElapsedTimeDict = new Dictionary<Wave, float>();
    private Dictionary<Wave, float> _waveSpawnTimeDict = new Dictionary<Wave, float>();

    private Action<Wave> _spawnAction;

    public SpawnTimeCalculator(WaveData[] waveDatas, Action<Wave> spawnAction)
    {
        foreach (var data in waveDatas)
        {
            _waveElapsedTimeDict.Add(data.Wave, 0);
            _waveSpawnTimeDict.Add(data.Wave, data.SpawnDelayTime);
        }

        _spawnAction = spawnAction;
    }

    public void Calculate()
    {
        foreach (var item in _waveSpawnTimeDict)
        {
            _waveElapsedTimeDict[item.Key] += Time.deltaTime;
            if (_waveElapsedTimeDict[item.Key] >= _waveSpawnTimeDict[item.Key])
            {
                _spawnAction?.Invoke(item.Key);
                _waveElapsedTimeDict[item.Key] = 0f;
            }
        }
    }
}