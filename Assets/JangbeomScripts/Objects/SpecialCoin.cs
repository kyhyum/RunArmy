using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialCoin : MonoBehaviour
{
    
    void Update()
    {
        transform.Rotate(new Vector3(0, 0, 100f) * Time.deltaTime);//ȸ��
    }
    private void OnTriggerEnter(Collider other) // �浹 ����
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
            PacmanGameManager.Instance.IncreaseScore(50);
        }
    }
}
