using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShootingGameManager : MonoBehaviour
{
    public bool gameEndCheck=false;

    public int cannonstatus = Math.Clamp(0, -1, 1);

    public TextMeshProUGUI gameTime;
    public float time=30;
    public TextMeshProUGUI Score;
    public int score=0;


    public GradeCalculator gradeCalculator;
    public CalculatorPoint calculatorPoint;

    public static ShootingGameManager Instance;
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        cannonstatus = 0;
        SoundManager.Instance.PlayBGM(BGM.Shooting);
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameEndCheck)
        {
            time -= Time.deltaTime;
            gameTime.text = time.ToString("0.00");
            End();
        }
    }

    public void ScorePlusUpdate()
    {
        if (!ShootingGameManager.Instance.gameEndCheck) 
        {
        score++;
        Score.text = score.ToString();
        }
    }

    void End()
    {
        if (time <= 0)
        {
            gameEndCheck = true;
            SoundManager.Instance.StopBGM();
            calculatorPoint.CalculateScorePoint(gradeCalculator, score);
        }
    }


}
