using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoingUpScore
{
    public void CalculateScore(GradeCalculator gradeCalculator, float elapsedTime)
    {
        int integerTime = (int)elapsedTime;
        string grade = gradeCalculator.CalculateGrade(integerTime, out int gold, out int reverseScore);
        
        if (SceneLoadManager.Instance.IsStoryMode)
        {
            Popup_StoryResult result = UIManager.Instance.ShowPopup<Popup_StoryResult>();
            result.PlayShowAnimation();

            bool isClear = integerTime - gradeCalculator.Data.ScoreCriteria[2] <= 0;
            if (isClear)
            {
                result.SetPopup("게임 결과", "다음 스테이지", "나가기",
                    () => SceneLoadManager.Instance.LoadNextStoryScene(),
                    () => SceneLoadManager.Instance.ToMain()
                    );
            }
            else
            {
                result.SetPopup("게임 결과", "다시하기", "나가기",
                    () => SceneLoadManager.Instance.LoadScene(SceneLoadManager.Instance.CurrentMiniGame),
                    () => SceneLoadManager.Instance.ToMain()
                    );
            }

            result.SetText(isClear);

            PlayerDataManager.Instance.SaveBestScore(SceneLoadManager.Instance.CurrentMiniGame, integerTime, true);
        }
        else
        {
            Popup_Result result = UIManager.Instance.ShowPopup<Popup_Result>();

            result.PlayShowAnimation();
            result.SetPopup("게임 결과", "다시하기", "나가기",
                    () => SceneLoadManager.Instance.LoadScene(SceneLoadManager.Instance.CurrentMiniGame),
                    () => SceneLoadManager.Instance.ToArcade()
                    );
            result.SetValue(integerTime, gold, grade, "경과 시간 :");
        }

        PlayerDataManager.Instance.playerData.AddCoins(gold);
    }
}