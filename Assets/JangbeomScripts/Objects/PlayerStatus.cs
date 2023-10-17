using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    private bool isInvincible = false;
    private float invincibleTime = 5f;
    private float blinkTime = 0.2f;
    private Renderer rend;

    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    void Update()
    {
        if (isInvincible)
        {
            
            invincibleTime -= Time.deltaTime;

            // ���� �������� �����̵��� ����
            if (Mathf.Floor(invincibleTime / blinkTime) % 2 == 0)
            {
                rend.enabled = false;
            }
            else
            {
                rend.enabled = true;
            }

            // ���� �ð��� ������ �ʱ�ȭ
            if (invincibleTime <= 0f)
            {
                isInvincible = false;
                rend.enabled = true;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy") && !isInvincible)
        {
            PacmanGameManager.Instance.GameOver();
        }
        else if (other.CompareTag("SpecialCoin"))
        {
            isInvincible = true;
            invincibleTime = 5f;
           
        }
    }
}
