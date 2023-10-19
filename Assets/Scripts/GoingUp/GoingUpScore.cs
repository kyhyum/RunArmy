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
            result.SetText(true);
            result.SetPopup(() => SceneLoadManager.Instance.LoadNextStoryScene(), () => SceneLoadManager.Instance.LoadScene(SceneLoadManager.Instance.CurrentScene));
        }
        else
        {
            Popup_Result result = UIManager.Instance.ShowPopup<Popup_Result>();

            result.PlayShowAnimation();
            result.SetValue(integerTime, gold, grade, "경과 시간 :");

        }

    }

    
}