using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InfiniteStair_UIMain : MonoBehaviour
{
    [SerializeField] private Button settingButton;
    [SerializeField] private int temp;
    private void Awake()
    {
        settingButton.onClick.AddListener(OpenPopup_Setting);
    }

    public void OpenPopup_Setting()
    {
        Popup_Setting popup = UIManager.Instance.ShowPopup<Popup_Setting>();
        popup.PlayShowAnimation();
        popup.SetPopup("환경설정", Confirm, Close);
        popup.Refresh();
        temp = popup.temp;
    }

    public void Confirm()
    {
        SceneManager.LoadScene("InfiniteStairScene");
        UIManager.Instance.ClearPopUpDic();
    }
    
    public void Close()
    {
        InfiniteStairGameManager.Instance.healthMinus = temp;
    }

}
