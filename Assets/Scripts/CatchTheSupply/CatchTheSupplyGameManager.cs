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

    public GradeCalculator gradeCalculator;
    public CalculatorPoint calculatorPoint;

    public float time = 30;
    void Start()
    {
        SoundManager.Instance.PlayBGM(BGM.Catch);
        gameEndCheck = false;
        Instance = this;
        //gradeCalculator = GetComponent<GradeCalculator>();

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
            SoundManager.Instance.StopBGM();
            calculatorPoint.CalculateScorePoint(gradeCalculator, nowScrore);
        }
    }

}
