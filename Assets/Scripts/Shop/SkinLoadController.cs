using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinLoadController : MonoBehaviour
{
    public static GameObject skinToLoad;

    private void Awake()
    {
        Instantiate(skinToLoad, transform);
    }
}
