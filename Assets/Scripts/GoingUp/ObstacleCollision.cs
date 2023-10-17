using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObstacleCollision
{
    public void ApplyCollision(Rigidbody oppositeRigid, Vector3 towardTargetVec, float mass)
    {
        oppositeRigid.AddForce(towardTargetVec * mass, ForceMode.Impulse);
    }
}
