using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MiniGame
{
    GoingUp,

}

[CreateAssetMenu(fileName = "MiniGame", menuName = "GradeData/MiniGame")]
public class GradeData : ScriptableObject
{
    [field: SerializeField] public MiniGame MiniGame { get; private set; }
    [field: SerializeField] public int Elite { get; private set; }
    [field: SerializeField] public int First { get; private set; }
    [field: SerializeField] public int Second { get; private set; }
    [field: SerializeField] public int Third { get; private set; }
}
