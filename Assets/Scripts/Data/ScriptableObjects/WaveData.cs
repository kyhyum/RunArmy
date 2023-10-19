using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Wave
{
    Small,
    Medium,
    Large,
}

[CreateAssetMenu(fileName = "Default", menuName = "Create/Wave")]
public class WaveData : ScriptableObject
{
    [field: SerializeField] public Wave Wave { get; private set; }
    [field: SerializeField] public float SpawnDelayTime { get; private set; }
    [field: SerializeField] public Obstacle[] Obstacles { get; private set; }
}
