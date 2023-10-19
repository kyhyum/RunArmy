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
    public GameObject explainUI;
    public TMP_Text countdownText;
    private float startTime;
    public AudioSource backgroundMusic;
    public AudioSource successSound;
    public AudioSource overSound;


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

        successSound.Play();
    }
    
    public void GameOver()  
    {
        uiOver.SetActive(true);
        Time.timeScale = 0f;

        overSound.Play();
    }
    public void Retry()
    {
        uiOver.SetActive(false);
        uiSuccess.SetActive(false);
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1.0f;

        score = 0;

    }
    private IEnumerator StartGame()
    {
        explainUI.SetActive(true);
        yield return new WaitForSecondsRealtime(4);
        explainUI.SetActive(false);


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
        Time.timeScale = 1f; // 게임 시작

       
    }
}
