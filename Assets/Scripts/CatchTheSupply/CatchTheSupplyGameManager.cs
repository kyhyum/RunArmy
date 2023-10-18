using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CatchTheSupplyGameManager : MonoBehaviour
{
    public TextMeshProUGUI nowScoreText;
    public int nowScrore;
    public TextMeshProUGUI maxScoreText;
    public int maxScrore=15;
    public static CatchTheSupplyGameManager Instance;

    public TextMeshProUGUI timeText;

    public GameObject EndPanel;

    public bool gameEndCheck;

    public static Cannon cannon;

    float time = 0;
    void Start()
    {
        gameEndCheck = false;
        Instance = this;        
        maxScoreText.text = maxScrore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameEndCheck) 
        {
            time += Time.deltaTime;
            timeText.text = time.ToString("0.00");
        }
    }

    public void ScorePlusUpdate() 
    {
        nowScrore++;
        End();
        nowScoreText.text = nowScrore.ToString();
    }
    public void ScoreMinusUpdate()
    {
        nowScrore--;
        nowScoreText.text = nowScrore.ToString();
    }

    void End() 
    {
        if (nowScrore >= maxScrore) 
        {
            gameEndCheck= true;
            EndPanel.SetActive(true);
        }
    }
}
