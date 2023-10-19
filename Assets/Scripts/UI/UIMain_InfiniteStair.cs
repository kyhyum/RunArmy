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
        settingButton.onClick.AddListener(OpenPopup_Pause);
    }

    public void OpenPopup_Pause()
    {
        Popup_Pause popup = UIManager.Instance.ShowPopup<Popup_Pause>();
        popup.PlayShowAnimation();
        popup.SetPopup("일시정지","다시 시작", "게임 재개", Confirm, Close);
        temp = InfiniteStairGameManager.Instance.healthMinus;
        InfiniteStairGameManager.Instance.healthMinus = 0;
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
