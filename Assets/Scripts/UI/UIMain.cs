using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIMain : MonoBehaviour
{
    [SerializeField] private Button PauseButton;
    public void Awake()
    {
        PauseButton.onClick.AddListener(OpenPopup_Pause);
    }

    public virtual void OpenPopup_Pause()
    {
        Popup_Pause popup = UIManager.Instance.ShowPopup<Popup_Pause>();
        popup.PlayShowAnimation();
        popup.SetPopup("일시정지","다시 시작", "게임 재개", Confirm, Close);
        Open();
    }

    public virtual void Open() { }

    public void Confirm()
    {
        SceneLoadManager.Instance.LoadScene(SceneLoadManager.Instance.CurrentMiniGame);
        UIManager.Instance.ClearPopUpDic();
    }
    
    public virtual void Close()
    {

    }

}
