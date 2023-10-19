using UnityEngine;

[CreateAssetMenu(fileName = "New Skin", menuName = "Game/SkinSO")]
public class SkinSO : ScriptableObject
{
    public string skinName;
    public int price;
    public bool locked;
    public GameObject skinPrefab;
}
