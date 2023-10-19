using UnityEngine;

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
        Popup_Result popup = UIManager.Instance.ShowPopup<Popup_Result>();
        popup.SetPopup("게임 결과", "다시하기", "나가기", AcadeConfirm, AcadeClose);

        int count = rotateGameScoreManager.score;
        grade = gradeCalculator.CalculateGrade(count, out gold);

        popup.SetValue(count, gold, grade);
        PlayerDataManager.Instance.playerData.AddCoins(gold);
    }

    public void AcadeConfirm()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("RotateGame");
        UIManager.Instance.ClearPopUpDic();
    }

    public void AcadeClose()
    {
        //TODO : 씬 이동
    }
}
