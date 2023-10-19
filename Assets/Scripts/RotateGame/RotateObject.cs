using UnityEngine;
using UnityEngine.SceneManagement;

public class RotateObject : MonoBehaviour
{
    [SerializeField] private float initialRotationSpeed;
    [SerializeField] private float accelerationRate;
    [SerializeField] private float phaseDuration;
    private float timeInCurrentPhase = 0.0f;
    private float rotationSpeed = 0.0f;
    private int rotateDirection = -1;
    private float maxRotationSpeed = 300.0f;

    public GradeCalculator gradeCalculator;
    public RotateGameScoreManager rotateGameScoreManager;

    private void Start()
    {
        rotationSpeed = initialRotationSpeed;
    }

    private void Update()
    {

        timeInCurrentPhase += Time.deltaTime;

        if (timeInCurrentPhase >= phaseDuration)
        {
            timeInCurrentPhase = 0.0f;

            rotationSpeed += accelerationRate;
            if (rotationSpeed > maxRotationSpeed)
            {
                rotationSpeed = maxRotationSpeed;
            }

            rotateDirection = -rotateDirection;
        }

        Vector3 rotation = Vector3.zero;
        rotation[1] = rotationSpeed * rotateDirection * Time.deltaTime;
        transform.Rotate(rotation);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Hit");
            Time.timeScale = 0.0f;
            GameOver();
        }
    }

    public void GameOver()
    {
        int gold = 0;
        string grade;
        int count = rotateGameScoreManager.score;

        if (!SceneLoadManager.Instance.IsStoryMode)
        {
            Popup_Result popup = UIManager.Instance.ShowPopup<Popup_Result>();
            popup.SetPopup("게임 결과", "다시하기", "나가기", AcadeConfirm, AcadeClose);

            
            grade = gradeCalculator.CalculateGrade(count, out gold);

            popup.SetValue(count, gold, grade);
            PlayerDataManager.Instance.playerData.AddCoins(gold);
        }
        else
        {
            Popup_StoryResult popup = UIManager.Instance.ShowPopup<Popup_StoryResult>();
            if (count >= gradeCalculator.Data.ScoreCriteria[2])
            {
                popup.SetPopup("게임 결과", "다음 스테이지", "나가기", StoryConfirmClear, StoryClose);
                popup.SetText(true);
            }
            else
            {
                popup.SetPopup("게임 결과", "다시 하기", "나가기", StoryConfirmNotClear, StoryClose);
                popup.SetText(false);
            }
        }
            
    }

    public void AcadeConfirm()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("RotateGame");
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

    public void StoryClose()
    {
        SceneLoadManager.Instance.LoadScene(SceneType.MainMenuScene);
    }
    public void StoryConfirmNotClear()
    {
        SceneManager.LoadScene("InfiniteStairScene");
    }
}
