using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShootingGameManager : MonoBehaviour
{
    public bool gameEndCheck=false;
    public GameObject EndPanel;

    public int cannonstatus = Math.Clamp(0, -1, 1);

    public TextMeshProUGUI gameTime;
    public float time=30;
    public TextMeshProUGUI Score;
    public int score=0;


    public string rank;
    public int bestScore;

    public static ShootingGameManager Instance;
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        cannonstatus = 0;
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
            EndPanel.SetActive(true);
            Rank();
        }
    }

    public void Rank() 
    {
        if (score >= 10)
        {
            rank = "ЦЏБо";
        }
        else if (score >= 7)
        {
            rank = "1Бо";
        }
        else if (score >= 5)
        {
            rank = "2Бо";
        }
        else 
        {
            rank = "ЦѓБо";
        }
    }
}
