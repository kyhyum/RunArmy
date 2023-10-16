using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinPanel : MonoBehaviour
{
    public GameObject skinToEquip;

    public void EquipSkin()
    {
        SkinLoadController.skinToLoad = skinToEquip;
    }
}
