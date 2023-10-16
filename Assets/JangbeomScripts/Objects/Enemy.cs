using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public TMP_Text scoreText;
    public int scoreValue = 50;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
            PacmanGameManager.Instance.IncreaseScore(scoreValue);
        }
    }
}
