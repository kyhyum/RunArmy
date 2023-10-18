using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class StairAnimationData
{
    [SerializeField] private string StartGameParameterName = "IsStart";
    [SerializeField] private string RightLegUpParameterName = "RightLeg";
    [SerializeField] private string LeftLegUpParameterName = "LeftLeg";


    public int StartGameParameterHash { get; private set; }
    public int RightLegUpParameterHash { get; private set; }
    public int LeftLegUpParameterHash { get; private set; }
    public int UpStairingParameterHash { get; private set; }

    public void Initialize()
    {
        StartGameParameterHash = Animator.StringToHash(StartGameParameterName);
        RightLegUpParameterHash = Animator.StringToHash(RightLegUpParameterName);
        LeftLegUpParameterHash = Animator.StringToHash(LeftLegUpParameterName);
    }
}
