using UnityEngine;

public class RotateObject : MonoBehaviour
{
    public float rotationSpeed = 60.0f; // ��ħ�� ȸ�� �ӵ� (�ʴ� ����)
    public int rotationAxis = 0; // ȸ�� �� (0: X ��, 1: Y ��, 2: Z ��)

    private void Update()
    {
        // ��ħ�� ȸ����ŵ�ϴ�. ȸ�� �࿡ ���� ȸ���� �����մϴ�.
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
