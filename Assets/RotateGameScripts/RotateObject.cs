using UnityEngine;

public class RotateObject : MonoBehaviour
{
    public float rotationSpeed = 60.0f; // 시침의 회전 속도 (초당 각도)
    public int rotationAxis = 0; // 회전 축 (0: X 축, 1: Y 축, 2: Z 축)

    private void Update()
    {
        // 시침을 회전시킵니다. 회전 축에 따라 회전을 설정합니다.
        Vector3 rotation = Vector3.zero;
        rotation[rotationAxis] = rotationSpeed * Time.deltaTime;
        transform.Rotate(rotation);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("HIt");
        }
    }
}
