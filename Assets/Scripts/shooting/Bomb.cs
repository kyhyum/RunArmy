using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public float speed =7f;
    public GameObject spawnOBJ;
    private Cannon spawn;
    private void Start()
    {
        spawn = spawnOBJ.GetComponent<Cannon>();
    }
    // Update is called once per frame
    void Update()
    {
        if (true)
        {
            transform.Translate(0, 0, speed * Time.deltaTime);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        spawn.InsertQueue(gameObject);
        gameObject.SetActive(false);
    }
}
