using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShootingGameManager : MonoBehaviour
{
    private bool gameEndCheck=false;
    public GameObject EndPanel;

    public int cannonstatus = Math.Clamp(0, -1, 1);

    public TextMeshProUGUI gameTime;
    public float time=30;
    public TextMeshProUGUI Score;
    public int score=0;

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
        score++;
        Score.text = score.ToString();
    }

    void End()
    {
        if (time <= 0)
        {
            gameEndCheck = true;
            EndPanel.SetActive(true);
        }
    }
}
