using UnityEngine;

public class RotateObjectT : MonoBehaviour
{
    public float initialRotationSpeed = 30.0f; // 초기 회전 속도
    public float accelerationRate = 10.0f; // 회전 속도 증가율
    public float phaseDuration = 5.0f; // 각 페이즈의 지속 시간
    private float timeInCurrentPhase = 0.0f;
    private float rotationSpeed = 0.0f;
    private int phase = 1;
    private int rotateDirection = 1;

    private void Start()
    {
        // 시작 시 초기 회전 속도 및 부호를 설정
        rotationSpeed = initialRotationSpeed;
    }

    private void Update()
    {
        timeInCurrentPhase += Time.deltaTime;

        if (timeInCurrentPhase >= phaseDuration)
        {
            // 페이즈 지속 시간이 경과하면 다음 페이즈로 이동
            phase++;
            timeInCurrentPhase = 0.0f;

            // 회전 속도 증가 및 부호 변경
            rotationSpeed += accelerationRate;
            rotateDirection = -rotateDirection; // 부호 변경
        }

        // 회전
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
