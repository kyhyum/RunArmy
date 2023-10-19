using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject rangeObject;
    BoxCollider rangeCollider;
    public GameObject[] Model;
    public Queue<GameObject> T_queue;
    public int count;
    public float delay = 1;

    private void Awake()
    {
        T_queue = new Queue<GameObject>();
        rangeCollider = rangeObject.GetComponent<BoxCollider>();
    }

    void Start()
    {
        for (int i = 0; i < count; i++)
        {
            GameObject choiceModel = Model[Random.Range(0, Model.Count())];
            GameObject t_object = Instantiate(choiceModel, this.gameObject.transform);
            T_queue.Enqueue(t_object);
            t_object.SetActive(false);
        }

        StartCoroutine(Maker());
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


    IEnumerator Maker()
    {
        while (!CatchTheSupplyGameManager.Instance.gameEndCheck)
        {
            if (T_queue.Count != 0)
            {

                GameObject t_object = GetQueue();
                t_object.transform.position = Return_RandomPosition();

            }
            yield return new WaitForSeconds(delay);
        }
    }

    Vector3 Return_RandomPosition()
    {
        Vector3 originPosition = rangeObject.transform.position;
        // 콜라이더의 사이즈를 가져오는 bound.size 사용
        float range_X = rangeCollider.bounds.size.x;
        float range_Z = rangeCollider.bounds.size.z;

        range_X = Random.Range((range_X / 2) * -1, range_X / 2);
        range_Z = Random.Range((range_Z / 2) * -1, range_Z / 2);
        Vector3 RandomPostion = new Vector3(range_X, 0f, range_Z);

        Vector3 respawnPosition = originPosition + RandomPostion;
        return respawnPosition;
    }
}
