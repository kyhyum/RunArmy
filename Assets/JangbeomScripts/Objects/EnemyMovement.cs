using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    private Transform player;
    private NavMeshAgent nav;
    public float movementSpeed = 3f;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        
        nav = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        nav.SetDestination(player.position);
    }
}
