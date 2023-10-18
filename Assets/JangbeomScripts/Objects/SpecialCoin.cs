using UnityEngine;

public class SpecialCoin : MonoBehaviour
{
    private bool isCollected = false;

    void Update()
    {
        transform.Rotate(new Vector3(0, 0, 100f) * Time.deltaTime);//ȸ��
    }
    private void OnTriggerEnter(Collider other) // �浹 ����
    {
        if (other.CompareTag("Player") && !isCollected)
        {
            isCollected = true;
            Destroy(gameObject);
            PacmanGameManager.Instance.IncreaseScore(50);
            ApplySpeedBoost(other.gameObject);
        }
    }

    private void ApplySpeedBoost(GameObject player)
    {
        PlayerStatus playerScript = player.GetComponent<PlayerStatus>();
        if (playerScript != null)
        {
            playerScript.ApplySpeedBoost(3, 3f); // 3��ŭ�� �ӵ� ����, 3�� ���� ����
        }
    }
}
