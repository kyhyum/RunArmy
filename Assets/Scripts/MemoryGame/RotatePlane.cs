using UnityEngine;

public class RotatePlane : MonoBehaviour
{
    public float rotationSpeed = 30.0f;

    void Update()
    {
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
    }
}
