using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InfiniteStair_UIMain : UIMain
{
    [SerializeField] private int temp;

    public override void Open()
    {
        temp = InfiniteStairGameManager.Instance.healthMinus;
        InfiniteStairGameManager.Instance.healthMinus = 0;
    }
    
    public override void Close()
    {
        InfiniteStairGameManager.Instance.healthMinus = temp;
    }

}
