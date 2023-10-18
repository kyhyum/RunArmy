using TMPro;
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PacmanGameManager : MonoBehaviour
{
    public static PacmanGameManager Instance;

    public int score = 0;
    public TMP_Text scoreText;
    public GameObject uiOver;
    public GameObject uiSuccess;
    public TMP_Text countdownText;
    private float startTime;


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
        if (countdownText != null)
        {
            Time.timeScale = 0f;
            StartCoroutine(StartGame());
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
    private IEnumerator StartGame()
    {
        countdownText.text = "3";
        startTime = Time.realtimeSinceStartup;
        yield return new WaitForSecondsRealtime(1);
        countdownText.text = "2";
        yield return new WaitForSecondsRealtime(1);
        countdownText.text = "1";
        yield return new WaitForSecondsRealtime(1);
        countdownText.text = "GO!";
        yield return new WaitForSecondsRealtime(1);
        countdownText.gameObject.SetActive(false);
        Time.timeScale = 1f; // ���� ����

        //int countdownTime = 3;
        //while (countdownTime > 0)
        //{
        //    countdownText.text = countdownTime.ToString();
        //    yield return new WaitForSeconds(1);
        //    countdownTime--;
        //}
        //countdownText.text = "GO!";
        //yield return new WaitForSeconds(1);
        //countdownText.gameObject.SetActive(false);
        //Time.timeScale = 1.0f; //���� ����
    }
}
