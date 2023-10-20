using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShootingGameManager : MonoBehaviour
{
    public bool gameEndCheck=false;

    public int cannonstatus = Math.Clamp(0, -1, 1);

    public TextMeshProUGUI gameTime;
    public float time=30;
    public TextMeshProUGUI Score;
    public int score=0;
    private PlayerDataManager playerDataManager;

    public GradeCalculator gradeCalculator;


    public static ShootingGameManager Instance;
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        cannonstatus = 0;
        SoundManager.Instance.PlayBGM(BGM.Shooting);
        playerDataManager = PlayerDataManager.Instance;
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
            GameOver();
        }
    }

    public void GameOver()
    {
        int gold = 0;
        string grade;
        grade = gradeCalculator.CalculateGrade(score, out gold);
        //아케이드 모드일 경우
        if (!SceneLoadManager.Instance.IsStoryMode)
        {
            Popup_Result popup = UIManager.Instance.ShowPopup<Popup_Result>();
            popup.SetPopup("게임 결과", "다시하기", "나가기", AcadeConfirm, AcadeClose);

            popup.SetValue(score, gold, grade);
            if (score >= playerDataManager.LoadBestScore(MiniGame.InfiniteStairScene))
            {
                playerDataManager.SaveBestScore(MiniGame.InfiniteStairScene, score);
            }
        }
        //스토리 모드일 경우
        else
        {
            Popup_StoryResult popup = UIManager.Instance.ShowPopup<Popup_StoryResult>();
            if (score >= gradeCalculator.Data.ScoreCriteria[2])
            {
                // 깻을 경우
                popup.SetPopup("게임 결과", "다음 스테이지", "나가기", StoryConfirmClear, StoryClose);
                popup.SetText(true);
            }
            else
            {
                // 못 꺴을 경우
                popup.SetPopup("게임 결과", "다시 하기", "나가기", StoryConfirmNotClear, StoryClose);
                popup.SetText(false);
            }
        }
        PlayerDataManager.Instance.SaveBestScore(MiniGame.ParkStageScene2, score);
        playerDataManager.playerData.coins += gold;
    }
    public void AcadeConfirm()
    {
        SceneManager.LoadScene("ParkStageScene2");
        UIManager.Instance.ClearPopUpDic();
    }
    public void AcadeClose()
    {
        SceneLoadManager.Instance.ToArcade();
    }
    public void StoryConfirmNotClear()
    {
        SceneManager.LoadScene("ParkStageScene2");
    }
    public void StoryConfirmClear()
    {
        SceneLoadManager.Instance.LoadNextStoryScene();
    }

    public void StoryClose()
    {
        SceneLoadManager.Instance.LoadScene(SceneType.MainMenuScene);
    }
}
