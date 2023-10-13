using UnityEngine;

public class ROPlayerController : MonoBehaviour
{
    public float jumpForce = 5.0f; // ���� ��

    private Rigidbody rb;

    void Start()
    {
        // Rigidbody ������Ʈ�� �����ɴϴ�.
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // �����̽��ٸ� ������ �����մϴ�.
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    void Jump()
    {
        // �÷��̾ �������� ������ŵ�ϴ�.
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }
}
