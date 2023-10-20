using UnityEngine;

public class GoingUp : MonoBehaviour
{
    [SerializeField] private GradeData data;

    private GoingUpUI _goingUpUI;
    private float _elapsedTime = 0f;
    private bool _isClear;

    private void Awake()
    {
        _goingUpUI = FindAnyObjectByType<GoingUpUI>();
    }

    void Start()
    {
        SoundManager.Instance.PlayBGM(BGM.GoingUp);
        
    }

    private void Update()
    {
        if (_goingUpUI != null && !_isClear)
        {
            _elapsedTime += Time.deltaTime;
            _goingUpUI.ShowElapsedTime(_elapsedTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // 너무 많이 호출될까봐 Layer Collision Matrix 처리 해줬음
        if (other.TryGetComponent(out CharacterController controller))
        {
            Clear(controller);
        }
    }

    public void Clear(CharacterController controller)
    {
        Time.timeScale = 0f;
        _isClear = true;
        controller.enabled = false;
        SoundManager.Instance.StopBGM();
        GoingUpScore goingUpScore = new GoingUpScore();
        GradeCalculator gradeCalculator = FindAnyObjectByType<GradeCalculator>();
        goingUpScore.CalculateScore(gradeCalculator, _elapsedTime);
    }
}
