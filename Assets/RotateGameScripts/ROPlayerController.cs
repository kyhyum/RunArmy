using UnityEngine;

public class ROPlayerController : MonoBehaviour
{
    public float jumpForce = 5.0f; // 점프 힘

    private Rigidbody rb;

    void Start()
    {
        // Rigidbody 컴포넌트를 가져옵니다.
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // 스페이스바를 누르면 점프합니다.
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    void Jump()
    {
        // 플레이어를 위쪽으로 점프시킵니다.
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }
}
