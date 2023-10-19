using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Drop : MonoBehaviour
{
    public float speed;
    private bool CollisionEnter = false;
    private float destroyTime = 0;
    public GameObject spawnOBJ;
    public Spawner spawn;
    public virtual void Start()
    {
        spawn = spawnOBJ.GetComponent<Spawner>();
    }
    private void OnEnable()
    {
        CollisionEnter = false;
        destroyTime = 0f;
        speed = Random.Range(0.1f, 2f);
    }
    private void Update()
    {
        if (!CatchTheSupplyGameManager.Instance.gameEndCheck && !CollisionEnter)
        {
            transform.Translate(0, -speed * Time.deltaTime, 0);
        }
        if (CollisionEnter)
        { 
        SelfDestroy();
        }
        
    }
    public virtual void OnCollisionEnter(Collision target)
    {
        CollisionEnter = true;
    }
    private void SelfDestroy()
    {
        if (destroyTime <= 4f)    // TODO
        {
            destroyTime += Time.deltaTime;
        }

        if (destroyTime >= 4f)
        {
            spawn.InsertQueue(gameObject);
            gameObject.SetActive(false);
        }
    }
}
