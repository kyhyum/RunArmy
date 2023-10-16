using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndingScene : MonoBehaviour
{
    [Header("Ending Resource")]
    [SerializeField] private Sprite gutgunActive;
    [SerializeField] private Sprite gutgunReserve;
    [SerializeField] private Sprite himchanActive;
    [SerializeField] private Sprite himchanReserve;
    [SerializeField] private Sprite enlistment;
    [SerializeField] private Sprite discharge;

    [Header("Ending Panel")]
    [SerializeField] private Image resultImage;
    [SerializeField] private Image gutgun;
    [SerializeField] private Image himchan;
    [SerializeField] private TextMeshProUGUI gutgunText;
    [SerializeField] private TextMeshProUGUI himchanText;

    [Header("SelectPanel")]
    [SerializeField] private GameObject selectBackground;
    [SerializeField] private TextMeshProUGUI announcementText;
    [SerializeField] private Button mainButton;
    [SerializeField] private Button retryButton;

    [Header("Ending Sounds")]
    [SerializeField] private AudioClip clearClip;
    [SerializeField] private AudioClip failClip;

    private void OnEnable()
    {
        // TODO
        // StartScene 이동
        // MainMenuScene 이동
        // 버튼 연결
    }

    private void Start()
    {
        ShowGameOver();
    }

    private void Update()
    {
        if (Input.anyKey)
        {
            selectBackground.SetActive(true);
        }
    }

    private void OnDisable()
    {
    }

    public void ShowEnding(bool isClear)
    {
        if (isClear)
        {
            ShowClear();
        }
        else
        {
            ShowGameOver();
        }
    }

    private void ShowClear()
    {
        resultImage.sprite = discharge;
        gutgun.sprite = gutgunReserve;
        himchan.sprite = himchanReserve;
        gutgunText.text = "안녕~";
        himchanText.text = "내년에 또 봐!";

        announcementText.text = "무사히 전역하셨습니다!";

        SoundManager.Instance.PlaySFX(clearClip);
    }

    private void ShowGameOver()
    {
        resultImage.sprite = enlistment;
        gutgun.sprite = gutgunActive;
        himchan.sprite = himchanActive;
        gutgunText.text = "어서와.";
        himchanText.text = "훈련소는 처음이지?";

        announcementText.text = "입영일자로 회귀하였습니다.\n다시하시겠습니까?";
        SoundManager.Instance.PlaySFX(failClip);
    }
}
