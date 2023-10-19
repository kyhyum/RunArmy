using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalculatorPoint : MonoBehaviour
{
    public void CalculateScorePoint(GradeCalculator gradeCalculator, int Score)
    {
        //�����̵� ����� ���
        int score = Score;
        string grade = gradeCalculator.CalculateGrade(score, out int gold);

        if (SceneLoadManager.Instance.IsStoryMode)
        {
            Popup_StoryResult result = UIManager.Instance.ShowPopup<Popup_StoryResult>();
            result.PlayShowAnimation();

            bool isClear = score - gradeCalculator.Data.ScoreCriteria[2] <= 0;
            if (isClear)
            {
                result.SetPopup("���� ���", "���� ��������", "������",
                    () => SceneLoadManager.Instance.LoadNextStoryScene(),
                    () => SceneLoadManager.Instance.ToMain()
                    );
            }
            else
            {
                result.SetPopup("���� ���", "�ٽ��ϱ�", "������",
                    () => SceneLoadManager.Instance.LoadScene(SceneLoadManager.Instance.CurrentMiniGame),
                    () => SceneLoadManager.Instance.ToMain()
                    );
            }

            result.SetText(isClear);

            PlayerDataManager.Instance.SaveBestScore(SceneLoadManager.Instance.CurrentMiniGame, score, true);
        }
        else
        {
            Popup_Result result = UIManager.Instance.ShowPopup<Popup_Result>();

            result.PlayShowAnimation();
            result.SetValue(score, gold, grade, "���� :");
        }

        PlayerDataManager.Instance.playerData.AddCoins(gold);
    }

}
