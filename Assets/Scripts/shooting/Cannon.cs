using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Cannon : MonoBehaviour
{
    public GameObject[] Model;
    public Queue<GameObject> T_queue;
    public int count = 20;
    public GameObject BoomGameObjPosition;

    private void Awake()
    {
        T_queue = new Queue<GameObject>();
        //bombPosition = BoomGameObj.transform;
    }

    void Start()
    {
        for (int i = 0; i < count; i++)
        {
            GameObject choiceModel = Model[Random.Range(0, Model.Count())];
            GameObject t_object = Instantiate(choiceModel);
            T_queue.Enqueue(t_object);
            t_object.SetActive(false);
        }
    }

    private void Update()
    {
        //쿨타임을 넣을까 말까
    }

    public void InsertQueue(GameObject p_object)
    {
        T_queue.Enqueue(p_object);
        p_object.SetActive(false);
    }
    public Queue<GameObject> returnQueue()
    {
        return T_queue;
    }

    public GameObject GetQueue()
    {
        GameObject t_object = T_queue.Dequeue();
        t_object.SetActive(true);

        return t_object;
    }

    public void Shoot()
    {
        GameObject t_object = GetQueue();
        t_object.transform.position = BoomGameObjPosition.transform.position;
    }

    public void MoveLeft()
    {
        if (ShootingGameManager.Instance.cannonstatus > -1)
        {
            ShootingGameManager.Instance.cannonstatus -= 1;
            this.transform.position += new Vector3(-2, 0,0);
        }
    }

    public void MoveRight()
    {
        if (ShootingGameManager.Instance.cannonstatus < 1)
        {
            ShootingGameManager.Instance.cannonstatus += 1;
            this.transform.position += new Vector3(2, 0, 0);
        }
    }
}
