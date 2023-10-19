using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GradeCalculator : MonoBehaviour
{
    [SerializeField] private GradeData data;

    [SerializeField] private string[] grades = new string[5];
    [SerializeField] private int[] golds = new int[5];

    public string CalculateGrade(int score, out int gold, bool reverse = false)
    {
        string grade = string.Empty;
        gold = 0;

        for (int i = 0; i < grades.Length; i++)
        {
            int subScore = reverse ? score - data.ScoreCriteria[i] : data.ScoreCriteria[i] - score;

            if (subScore <= 0)
            {
                grade = grades[i];
                gold = golds[i];
                break;
            }
        }

        return grade;
    }
}