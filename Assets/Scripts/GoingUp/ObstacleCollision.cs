using System.Threading.Tasks;
using UnityEngine;

public class ObstacleCollision
{
    public async void ApplyCollision(CharacterController controller, Rigidbody oppositeRigid, Vector3 towardTargetVec, float mass, int waitMilliseconds)
    {
        oppositeRigid.AddForce(towardTargetVec * mass, ForceMode.Impulse);

        controller.SetImmovable();

        await Task.Delay(waitMilliseconds);

        controller.SetMovable();
    }
}
