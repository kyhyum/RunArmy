using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
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
    private PlayerDataManager playerDataManager;

    public float time = 30;
    void Start()
    {
        SoundManager.Instance.PlayBGM(BGM.Catch);
        gameEndCheck = false;
        Instance = this;
        playerDataManager = PlayerDataManager.Instance;

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
            GameOver();
        }
    }

    public void GameOver()
    {
        int gold = 0;
        string grade;
        grade = gradeCalculator.CalculateGrade(nowScrore, out gold);
        //아케이드 모드일 경우
        if (!SceneLoadManager.Instance.IsStoryMode)
        {
            Popup_Result popup = UIManager.Instance.ShowPopup<Popup_Result>();
            popup.SetPopup("게임 결과", "다시하기", "나가기", AcadeConfirm, AcadeClose);

            popup.SetValue(nowScrore, gold, grade);
            if (nowScrore >= playerDataManager.LoadBestScore(MiniGame.InfiniteStairScene))
            {
                playerDataManager.SaveBestScore(MiniGame.InfiniteStairScene, nowScrore);
            }
        }
        //스토리 모드일 경우
        else
        {
            Popup_StoryResult popup = UIManager.Instance.ShowPopup<Popup_StoryResult>();
            if (nowScrore >= gradeCalculator.Data.ScoreCriteria[2])
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
        PlayerDataManager.Instance.SaveBestScore(MiniGame.ParkStageScene, nowScrore);

        PlayerDataManager.Instance.playerData.coins += gold;
    }
    public void AcadeConfirm()
    {
        SceneManager.LoadScene("ParkStageScene");
        UIManager.Instance.ClearPopUpDic();
    }
    public void AcadeClose()
    {
        SceneLoadManager.Instance.ToArcade();
    }
    public void StoryConfirmNotClear()
    {
        SceneManager.LoadScene("ParkStageScene");
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
