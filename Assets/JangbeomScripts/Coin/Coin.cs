using TMPro;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public TMP_Text scoreText;
    void Update()
    {
        transform.Rotate(new Vector3(0, 0, 100f) * Time.deltaTime);//ȸ��
    }
    private void OnTriggerEnter(Collider other) // �浹 ����
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
            PacmanGameManager.Instance.IncreaseScore(10);
        }            
    }

   
}
