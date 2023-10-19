using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Popup_Setting : UIPopup
{
    public int temp;
    public override void Refresh()
    {
        temp = InfiniteStairGameManager.Instance.healthMinus;
        InfiniteStairGameManager.Instance.healthMinus = 0;
    }
}
