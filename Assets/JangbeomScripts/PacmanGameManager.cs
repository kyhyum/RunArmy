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
        SoundManager.Instance.PlayBGM(BGM.MiniGameBGM3);

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

    public void GameOver()
    {
        int gold = 0;
        string grade;
        grade = gradeCalculator.CalculateGrade(score, out gold); // score ������ ������ ��Ÿ���� ������ �����մϴ�.
        //�����̵� ����� ���
        if (!SceneLoadManager.Instance.IsStoryMode)
        {
            Popup_Result popup = UIManager.Instance.ShowPopup<Popup_Result>();
            popup.SetPopup("���� ���", "�ٽ��ϱ�", "������", AcadeConfirm, AcadeClose);

            popup.SetValue(score, gold, grade);
            if (score >= PlayerDataManager.Instance.LoadBestScore(MiniGame.InfiniteStairScene))
            {
                PlayerDataManager.Instance.SaveBestScore(MiniGame.InfiniteStairScene, score);
            }
        }
        //���丮 ����� ���
        else
        {
            Popup_StoryResult popup = UIManager.Instance.ShowPopup<Popup_StoryResult>();
            if (score >= gradeCalculator.Data.ScoreCriteria[2])
            {
                // ���� ���
                popup.SetPopup("���� ���", "���� ��������", "������", StoryConfirmClear, StoryClose);
                popup.SetText(true);
            }
            else
            {
                // �� ���� ���
                popup.SetPopup("���� ���", "�ٽ� �ϱ�", "������", StoryConfirmNotClear, StoryClose);
                popup.SetText(false);
            }
        }

        PlayerDataManager.Instance.playerData.coins += gold;
        overSound.Play();
        Time.timeScale = 0f;
    }
    public void AcadeConfirm()
    {
        Time.timeScale = 1f;
        SceneLoadManager.Instance.LoadScene(SceneLoadManager.Instance.CurrentMiniGame);
        UIManager.Instance.ClearPopUpDic();
    }
    public void AcadeClose()
    {
        Time.timeScale = 1f;
        SceneLoadManager.Instance.ToArcade();
    }
    public void StoryConfirmNotClear()
    {
        Time.timeScale = 1f;
        SceneLoadManager.Instance.LoadScene(SceneLoadManager.Instance.CurrentMiniGame);
    }
    public void StoryConfirmClear()
    {
        Time.timeScale = 1f;
        SceneLoadManager.Instance.LoadNextStoryScene();
    }

    public void StoryClose()
    {
        Time.timeScale = 1f;
        SceneLoadManager.Instance.LoadScene(SceneType.MainMenuScene);
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
        Time.timeScale = 1f; // ���� ����
   
    }

    //private void SaveData()
    //{
    //    PlayerPrefs.SetFloat("PlayTime", playTime);
    //    PlayerPrefs.SetInt("Score", score);
    //    PlayerPrefs.Save();
    //}
}
