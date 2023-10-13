using UnityEngine;

public class RotateObjectT : MonoBehaviour
{
    public float initialRotationSpeed = 30.0f; // �ʱ� ȸ�� �ӵ�
    public float accelerationRate = 10.0f; // ȸ�� �ӵ� ������
    public float phaseDuration = 5.0f; // �� �������� ���� �ð�
    private float timeInCurrentPhase = 0.0f;
    private float rotationSpeed = 0.0f;
    private int phase = 1;
    private int rotateDirection = 1;

    private void Start()
    {
        // ���� �� �ʱ� ȸ�� �ӵ� �� ��ȣ�� ����
        rotationSpeed = initialRotationSpeed;
    }

    private void Update()
    {
        timeInCurrentPhase += Time.deltaTime;

        if (timeInCurrentPhase >= phaseDuration)
        {
            // ������ ���� �ð��� ����ϸ� ���� ������� �̵�
            phase++;
            timeInCurrentPhase = 0.0f;

            // ȸ�� �ӵ� ���� �� ��ȣ ����
            rotationSpeed += accelerationRate;
            rotateDirection = -rotateDirection; // ��ȣ ����
        }

        // ȸ��
        Vector3 rotation = Vector3.zero;
        rotation[1] = rotationSpeed * rotateDirection * Time.deltaTime;
        transform.Rotate(rotation);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Hit");
        }
    }
}
