
using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PacmanGameManager : MonoBehaviour
{
    public static PacmanGameManager Instance;

    public int score = 0;
    public TMP_Text scoreText;
    public GameObject uiOver;
    public GameObject uiSuccess;


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
        if(score == 550)
        {
            Success();
        }
        
    }
    public void IncreaseScore(int increment)
    {
        score += increment;
        UpdateScoreText();
    }
    public void Success()
    {
        uiSuccess.SetActive(true);
        Time.timeScale = 0f;
    }
    
    public void GameOver()  
    {
        uiOver.SetActive(true);
        Time.timeScale = 0f;
    }
    public void Retry()
    {
        uiOver.SetActive(false);
        uiSuccess.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1.0f;

        score = 0;

    }
}
