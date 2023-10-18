using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour, IPoolingObject<Obstacle>
{
    [Header("Collision")]
    [SerializeField] private float mass;
    [SerializeField] private int waitMilliseconds = 2000;
    private ObstacleCollision _obstacleCollision;
    private const string WATER_LAYER = "Water";

    [Header("ReturnToPool")]
    [SerializeField] private float deathTimer = 10f;
    public Wave Wave { get; private set; }
    private float _elapsedTime = 0f;
    private Action<Obstacle> _returnAction;

    public Rigidbody Rigidbody { get; private set; }

    private void Awake()
    {
        _obstacleCollision = new ObstacleCollision();
        Rigidbody = GetComponent<Rigidbody>();
    }

    private void OnDisable()
    {
        _elapsedTime = 0f;
    }

    private void Update()
    {
        CheckDeath();
    }

    public void Init(Action<Obstacle> returnAction)
    {
        _returnAction = returnAction;
    }

    public void SetWave(Wave wave)
    {
        Wave = wave;
    }

    public void ReturnToPool()
    {
        _returnAction?.Invoke(this);
    }

    private void CheckDeath()
    {
        _elapsedTime += Time.deltaTime;
        if (_elapsedTime >= deathTimer)
        {
            _returnAction?.Invoke(this);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.TryGetComponent(out CharacterController controller))
        {
            _obstacleCollision.ApplyCollision(controller, collision.rigidbody, -collision.GetContact(0).normal, mass, waitMilliseconds);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer(WATER_LAYER))
        {
            ReturnToPool();
        }
    }
}
