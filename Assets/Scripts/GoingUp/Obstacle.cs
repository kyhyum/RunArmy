using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [Header("Collision")]
    [SerializeField] private float mass;
    private ObstacleCollision _obstacleCollision;
    private const string WATER_LAYER = "Water";

    private void Awake()
    {
        _obstacleCollision = new ObstacleCollision();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.rigidbody != null)
        {
            _obstacleCollision.ApplyCollision(collision.rigidbody, -collision.GetContact(0).normal, mass);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer(WATER_LAYER))
        {
            // 스포너로 반환
        }
    }
}
