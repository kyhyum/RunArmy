using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RotateGame_UIMain : MonoBehaviour
{
    [SerializeField] private Button settingButton;
    [SerializeField] private int temp;
    private void Awake()
    {
        settingButton.onClick.AddListener(OpenPopup_Pause);
    }

    public void OpenPopup_Pause()
    {
        Time.timeScale = 0;
        Popup_Pause popup = UIManager.Instance.ShowPopup<Popup_Pause>();
        popup.PlayShowAnimation();
        popup.SetPopup("�Ͻ�����","�ٽ� ����", "���� �簳", Confirm, () => UIManager.Instance.ClosePopup(popup.gameObject));
    }

    public void Confirm()
    {
        Time.timeScale = 1;
        UnityEngine.SceneManagement.SceneManager.LoadScene("RotateGame");
        UIManager.Instance.ClearPopUpDic();
    }
}
