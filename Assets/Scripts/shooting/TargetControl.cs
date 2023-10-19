using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetControl : MonoBehaviour
{
    public Target[] target;
    int count;
    float time = 0f;
    public float regenTime = 2f;
    // Start is called before the first frame update
    void Start()
    {
        count= target.Length;
        for (int i = 0; i < count; ++i) 
        {
            target[i].gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!ShootingGameManager.Instance.gameEndCheck) 
        {
            if (time <= regenTime) 
            {
                time += Time.deltaTime;
            }
            if (time > regenTime) 
            {
                time = 0f;
                Open();
            }
        }
    }

    private void Open()
    {
        int random1 = UnityEngine.Random.Range(0, 2);
        int random2 = UnityEngine.Random.Range(0, 2);
        int random3 = UnityEngine.Random.Range(0, 2);
        int[] array = new int[] { random1, random2, random3};
        for (int i = 0; i < count; ++i) 
        {
            if (!target[i].live && (array[i] < 1)) 
            {
                target[i].gameObject.SetActive(true);
            }
        }
    }
}
