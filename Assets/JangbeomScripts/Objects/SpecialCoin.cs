using UnityEngine;

public class SpecialCoin : MonoBehaviour
{
    private bool isCollected = false;
    public AudioSource spcoinSound;

    void Update()
    {
        transform.Rotate(new Vector3(0, 0, 100f) * Time.deltaTime);//회전
    }
    private void OnTriggerEnter(Collider other) // 충돌 감지
    {
        if (other.CompareTag("Player") && !isCollected)
        {
            isCollected = true;
            Destroy(gameObject);
            spcoinSound.Play();
            PacmanGameManager.Instance.IncreaseScore(50);
            ApplySpeedBoost(other.gameObject);
        }
    }

    private void ApplySpeedBoost(GameObject player)
    {
        PlayerStatus playerScript = player.GetComponent<PlayerStatus>();
        if (playerScript != null)
        {
            playerScript.ApplySpeedBoost(3, 3f); // 3만큼의 속도 증가, 3초 동안 유지
        }
    }
}
