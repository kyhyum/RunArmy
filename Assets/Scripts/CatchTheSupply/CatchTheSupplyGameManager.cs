using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class CatchTheSupplyGameManager : MonoBehaviour
{
    public TextMeshProUGUI nowScoreText;
    public int nowScrore;
    public static CatchTheSupplyGameManager Instance;

    public TextMeshProUGUI timeText;

    public GameObject EndPanel;

    public bool gameEndCheck;

    private string rank;

    float time = 30;
    void Start()
    {
        gameEndCheck = false;
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameEndCheck)
        {
            time -= Time.deltaTime;
            timeText.text = time.ToString("0.00");
            End();
        }
    }

    public void ScorePlusUpdate()
    {
        nowScrore++;
        nowScoreText.text = nowScrore.ToString();
    }
    public void ScoreMinusUpdate()
    {
        nowScrore--;
        nowScoreText.text = nowScrore.ToString();
    }

    void End()
    {
        if (time <= 0)
        {
            gameEndCheck = true;
            EndPanel.SetActive(true);
            Rank();
        }
    }
    public void Rank()
    {
        if (nowScrore >= 20)
        {
            rank = "ЦЏБо";
        }
        else if (nowScrore >= 15)
        {
            rank = "1Бо";
        }
        else if (nowScrore >= 10)
        {
            rank = "2Бо";
        }
        else
        {
            rank = "ЦѓБо";
        }
    }
}
