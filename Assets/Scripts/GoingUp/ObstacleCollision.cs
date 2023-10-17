using UnityEngine;

public class ObstacleCollision
{
    public void ApplyCollision(Rigidbody oppositeRigid, Vector3 towardTargetVec, float mass)
    {
        oppositeRigid.AddForce(towardTargetVec * mass, ForceMode.Impulse);
    }
}
