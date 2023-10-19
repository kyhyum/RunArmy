using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Popup_StoryResult : UIPopup
{
    [SerializeField] private TMP_Text clearTxt;

    private string clearString;
    public override void Refresh()
    {
        clearTxt.text = clearString;
    }

    public void SetText(bool isClear)
    {
        if (isClear)
        {
            clearString = "�������� Ŭ����!";
        }
        else
        {
            clearString = "�������� ����!";
        }
    }

}
