using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Popup_Result : UIPopup
{
    private int scoreValue;
    private int moneyValue;
    private string degreeValue;

    [SerializeField] private TMP_Text scoreValueTxt;
    [SerializeField] private TMP_Text moneyValueTxt;
    [SerializeField] private TMP_Text degreeValueTxt;
    [SerializeField] private TMP_Text scoreTxt;

    public override void Refresh()
    {
        scoreValueTxt.text = scoreValue.ToString();
        moneyValueTxt.text = moneyValue.ToString();
        degreeValueTxt.text = degreeValue;
    }
    

    public void SetValue(int scoreValue, int moneyValue, string degreeValue, string scoreStr = null)
    {
        this.scoreValue = scoreValue;
        this.moneyValue = moneyValue;
        this.degreeValue = degreeValue;

        scoreTxt.text = scoreStr == null ? scoreTxt.text : scoreStr;
    }

    
}
