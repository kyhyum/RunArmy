using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Obstacle : MonoBehaviour
{
    [Header("Collision")]
    private Rigidbody _rigidbody;
    private ObstacleCollision _obstacleCollision;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _obstacleCollision = new ObstacleCollision();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.rigidbody != null)
        {
            _obstacleCollision.ApplyCollision(collision.rigidbody, -collision.GetContact(0).normal, _rigidbody.mass);
        }
    }
}
