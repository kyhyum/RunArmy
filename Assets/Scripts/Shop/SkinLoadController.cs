using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinLoadController : MonoBehaviour
{
    public static GameObject skinToLoad;
    public GameObject defaultSkin;

    private void Awake()
    {
        if(skinToLoad != null)
        {
            Instantiate(skinToLoad, transform);
            Destroy(defaultSkin);
        }
    }
}
