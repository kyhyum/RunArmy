
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PacmanGameManager : MonoBehaviour
{
    public static PacmanGameManager Instance;

    private int score = 0;
    public GameObject specialCoin;
    private GameObject[] normalCoins;
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
    private void Start()
    {
        normalCoins = GameObject.FindGameObjectsWithTag("coin");
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
        normalCoins = GameObject.FindGameObjectsWithTag("coin");
        if (normalCoins.Length <= 0)
        {
            ActivateSpecialCoin();
        }
    }

    private void ActivateSpecialCoin()
    {
        specialCoin.SetActive(true);
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
