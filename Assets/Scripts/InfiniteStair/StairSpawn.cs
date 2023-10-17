using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StairSpawn : MonoBehaviour
{
    public Queue<GameObject> stairQueue;
    public GameObject stair;
    private int count = 40;

    private void Awake()
    {
        stairQueue = new Queue<GameObject>();

        for (int i = 0; i < count; i++)
        {
            GameObject t_object = Instantiate(stair);
            stairQueue.Enqueue(t_object);
            t_object.SetActive(false);
        }
    }


    public void InsertQueue(GameObject p_object)
    {
        stairQueue.Enqueue(p_object);
        p_object.SetActive(false);
    }

    public Queue<GameObject> returnQueue()
    {
        return stairQueue;
    }

    public GameObject GetQueue()
    {
        GameObject stairObject = stairQueue.Dequeue();
        stairObject.SetActive(true);
        return stairObject;
    }

}
