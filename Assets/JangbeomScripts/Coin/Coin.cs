using TMPro;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public TMP_Text scoreText;
    void Update()
    {
        transform.Rotate(new Vector3(0, 0, 100f) * Time.deltaTime);//회전
    }
    private void OnTriggerEnter(Collider other) // 충돌 감지
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
            PacmanGameManager.Instance.IncreaseScore(10);
        }            
    }

   
}
