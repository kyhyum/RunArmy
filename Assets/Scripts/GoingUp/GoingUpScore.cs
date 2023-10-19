using System;
using UnityEngine;

public class GoingUpScore
{
    public void CalculateScore(GradeCalculator gradeCalculator, float _elapsedTime)
    {
        string grade = gradeCalculator.CalculateGrade((int)_elapsedTime, out int gold, true);

        Popup_Result result = UIManager.Instance.ShowPopup<Popup_Result>();
        result.PlayShowAnimation();
    }

    
}