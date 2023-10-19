using UnityEngine;

public class RotateObject : MonoBehaviour
{
    [SerializeField] private float initialRotationSpeed;
    [SerializeField] private float accelerationRate;
    [SerializeField] private float phaseDuration;
    private float timeInCurrentPhase = 0.0f;
    private float rotationSpeed = 0.0f;
    private int rotateDirection = -1;
    private float maxRotationSpeed = 300.0f;

    private bool gameEnded = false;

    [SerializeField] private RewardManager rewardManager;

    private void Start()
    {
        rotationSpeed = initialRotationSpeed;
    }

    private void Update()
    {
        if (gameEnded)
            return;

        timeInCurrentPhase += Time.deltaTime;

        if (timeInCurrentPhase >= phaseDuration)
        {
            timeInCurrentPhase = 0.0f;

            rotationSpeed += accelerationRate;
            if (rotationSpeed > maxRotationSpeed)
            {
                rotationSpeed = maxRotationSpeed;
            }

            rotateDirection = -rotateDirection;
        }

        Vector3 rotation = Vector3.zero;
        rotation[1] = rotationSpeed * rotateDirection * Time.deltaTime;
        transform.Rotate(rotation);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Hit");
            Time.timeScale = 0.0f;
            gameEnded = true;
            ROScoreManager.Instance.SetGameEnded();

            if (rewardManager != null)
            {
                rewardManager.EndGame(ROScoreManager.Instance.GetScore());
            }
        }
    }
}
