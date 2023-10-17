
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PacmanGameManager : MonoBehaviour
{
    public static PacmanGameManager Instance;

    private int score = 0;
    
    
    public TMP_Text scoreText;
    public GameObject uiOver;

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

    
    public void GameOver()  
    {
        uiOver.SetActive(true);
    }
    public void Retry()
    {
        uiOver.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1.0f;

        score = 0;

    }
}
