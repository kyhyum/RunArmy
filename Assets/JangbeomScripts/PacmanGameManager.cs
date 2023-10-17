using System;
using TMPro;
using UnityEngine;

public class PacmanGameManager : MonoBehaviour
{
    public static PacmanGameManager Instance;

    private int score = 0;
    public GameObject specialCoinPrefab;
    private int normalCoinCount = 35;

    public TMP_Text scoreText; 

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void UpdateScoreText()
    {
        scoreText.text = " " + score;
    }

    public void IncreaseScore(int increment)
    {
        score += increment;
        UpdateScoreText();
    }
    public void ConsumeNormalCoin()
    {
        normalCoinCount--;
        
        if(normalCoinCount <= 0)
        {
            ActivateSpecialCoin();
        }
    }

    private void ActivateSpecialCoin()
    {
        GameObject specialCoin = Instantiate(specialCoinPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        specialCoin.SetActive(true);
    }
}
