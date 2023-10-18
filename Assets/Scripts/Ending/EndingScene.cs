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
        // StartScene �̵�
        // MainMenuScene �̵�
        // ��ư ����
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
        gutgunText.text = "�ȳ�~";
        himchanText.text = "���⿡ �� ��!";

        announcementText.text = "������ �����ϼ̽��ϴ�!";

        SoundManager.Instance.PlaySFX(clearClip);
    }

    private void ShowGameOver()
    {
        resultImage.sprite = enlistment;
        gutgun.sprite = gutgunActive;
        himchan.sprite = himchanActive;
        gutgunText.text = "���.";
        himchanText.text = "�ƷüҴ� ó������?";

        announcementText.text = "�Կ����ڷ� ȸ���Ͽ����ϴ�.\n�ٽ��Ͻðڽ��ϱ�?";
        SoundManager.Instance.PlaySFX(failClip);
    }
}
