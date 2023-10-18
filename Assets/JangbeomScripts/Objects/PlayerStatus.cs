using System.Collections;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    private CharacterController characterController;
    private float originalSpeed;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        originalSpeed = characterController.speed;
    }


    public void ApplySpeedBoost(float speedIncrease, float duration)
    {
        StartCoroutine(SpeedBoostRoutine(speedIncrease, duration));
    }

    private IEnumerator SpeedBoostRoutine(float speedIncrease, float duration)
    {
        characterController.speed += speedIncrease;

        yield return new WaitForSeconds(duration);

        characterController.speed = originalSpeed;
    }
}
