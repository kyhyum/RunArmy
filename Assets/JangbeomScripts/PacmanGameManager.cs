using TMPro;
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PacmanGameManager : MonoBehaviour
{
    public static PacmanGameManager Instance;

    public int score = 0;

    public TMP_Text scoreText;
    public TMP_Text timeText;
    //public GameObject uiOver;
    //public GameObject uiSuccess;
    public GameObject explainUI;
    public TMP_Text countdownText;
    private float startTime;
    private float playTime;
    public AudioSource backgroundMusic;
    public AudioSource successSound;
    public AudioSource overSound;

    public GradeCalculator gradeCalculator;




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
    private void Update()
    {
        if (Time.timeScale != 0f)
        {
            playTime += Time.deltaTime; 
            timeText.text = " " + playTime.ToString("F2"); 
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
        //uiSuccess.SetActive(true);
  
        successSound.Play();
        Time.timeScale = 0f;
    }
    public void AcadeConfirm()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("packmanGameScene");
        UIManager.Instance.ClearPopUpDic();
    }
    public void AcadeClose()
    {
        //TODO : 씬 이동
    }
    public void StoryConfirm()
    {
        //TODO : 씬 이동
    }

    public void StoryClose()
    {
        //TODO : 씬 이동
    }

    public void GameOver()  
    {
        //uiOver.SetActive(true);       

        {
            int gold = 0;
            string grade;
            Popup_Result popup = UIManager.Instance.ShowPopup<Popup_Result>();
            popup.SetPopup("게임 결과", "다시하기", "나가기", AcadeConfirm, AcadeClose);

            grade = gradeCalculator.CalculateGrade(score, out gold); // score 변수는 점수를 나타냈을 것으로 가정합니다.
            popup.SetValue(score, gold, grade);
            if (score >= PlayerDataManager.Instance.LoadBestScore(MiniGame.packmanGameScene))
            {
                PlayerDataManager.Instance.SaveBestScore(MiniGame.packmanGameScene, score);
            }
        }

        overSound.Play();
        Time.timeScale = 0f; // 게임 일시정지
    }
   
    //public void Retry()
    //{
    //    uiOver.SetActive(false);
    //    uiSuccess.SetActive(false);
    //    UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
    //    Time.timeScale = 1.0f;

    //    score = 0;

    //}
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

    //private void SaveData()
    //{
    //    PlayerPrefs.SetFloat("PlayTime", playTime);
    //    PlayerPrefs.SetInt("Score", score);
    //    PlayerPrefs.Save();
    //}
}
