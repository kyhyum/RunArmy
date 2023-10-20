using System;
using TMPro;
using UnityEngine;
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

    [Header("Ending Sounds")]
    [SerializeField] private AudioClip clearClip;
    [SerializeField] private AudioClip failClip;

    private void Start()
    {
        mainButton.onClick.AddListener(() => SceneLoadManager.Instance.ToMain());
        ShowEnding();
    }

    private void Update()
    {
        if (Input.anyKey)
        {
            selectBackground.SetActive(true);
        }
    }

    private void OnDestroy()
    {
        mainButton.onClick.RemoveListener(() => SceneLoadManager.Instance.ToMain());
    }

    public void ShowEnding()
    {
        if (SceneLoadManager.Instance.ClearCount > Enum.GetValues(typeof(MiniGame)).Length / 2)
            ShowClear();
        else
            ShowGameOver();
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

        SceneLoadManager.Instance.ClearCount = 0;
    }

    private void ShowGameOver()
    {
        resultImage.sprite = enlistment;
        gutgun.sprite = gutgunActive;
        himchan.sprite = himchanActive;
        gutgunText.text = "어서와.";
        himchanText.text = "훈련소는 처음이지?";

        announcementText.text = "입영일자로 회귀하였습니다.";
        SoundManager.Instance.PlaySFX(failClip);

        SceneLoadManager.Instance.ClearCount = 0;
    }
}
