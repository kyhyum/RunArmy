using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MiniGame", menuName = "GradeData/MiniGame")]
public class GradeData : ScriptableObject
{
    [field: SerializeField] public int[] ScoreCriteria { get; private set; } = new int[5];
}