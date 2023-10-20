using TMPro;
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PacmanGameManager : MonoBehaviour
{
    public static PacmanGameManager Instance;

    public int score = 0;

    //public TMP_Text scoreText;
    //public TMP_Text bestScoreText;

    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text bestScoreText;
    public TMP_Text timeText;
    
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
        if (countdownText != null || PlayerDataManager.Instance != null)
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
    public void IncreaseScore(int points)
    {
        score += points;
        scoreText.text = score.ToString();
        
    }

    public void AcadeConfirm()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("packmanGameScene");
        UIManager.Instance.ClearPopUpDic();
    }
    public void AcadeClose()
    {
        SceneLoadManager.Instance.ToMain();
    }
    public void StoryConfirmClear()
    {
        SceneLoadManager.Instance.LoadNextStoryScene();
    }

    public void StoryConfirmNotClear()
    {
        SceneManager.LoadScene("packmanGameScene");
    }
    public void StoryClose()
    {
        SceneLoadManager.Instance.LoadScene(SceneType.MainMenuScene);
    }

    public void GameOver()  
    {
             
        int gold = 0;
        string grade;
        Popup_Result popup = UIManager.Instance.ShowPopup<Popup_Result>();
        popup.SetPopup("게임 결과", "다시하기", "나가기", AcadeConfirm, AcadeClose);
        grade = gradeCalculator.CalculateGrade(score, out gold);
        popup.SetValue(score, gold, grade);

        if (PlayerDataManager.Instance != null)
        {
            if (score >= PlayerDataManager.Instance.LoadBestScore(MiniGame.packmanGameScene))
            {
                PlayerDataManager.Instance.SaveBestScore(MiniGame.packmanGameScene, score);
                bestScoreText.text = "Best Score: " + score.ToString();
            }
        }


        overSound.Play();
        Time.timeScale = 0f; // 게임 일시정지
    }
   
  
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
   
}
