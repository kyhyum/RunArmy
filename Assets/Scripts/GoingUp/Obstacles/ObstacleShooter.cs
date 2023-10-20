using UnityEngine;

public class ObstacleShooter
{
    private Transform _targetTrans;
    private float _minPower;
    private float _maxPower;
    private float _absAngle;

    public ObstacleShooter(Transform transform, float minPower, float maxPower, float absAngle)
    {
        _targetTrans = transform;
        _minPower = minPower;
        _maxPower = maxPower;
        _absAngle = absAngle;
    }

    public void Shoot(Obstacle obstacle)
    {
        Vector3 shootingDir = _targetTrans.position - obstacle.transform.position;
        float randomAngle = UnityEngine.Random.Range(-_absAngle, _absAngle);
        float randomPower = UnityEngine.Random.Range(_minPower, _maxPower);
        Vector3 finalVec = UnityEngine.Quaternion.Euler(0, 0, randomAngle) * shootingDir;

        obstacle.Rigidbody.AddForce(finalVec * randomPower, ForceMode.Force);
    }
}