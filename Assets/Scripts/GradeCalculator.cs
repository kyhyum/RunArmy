using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GradeCalculator : MonoBehaviour
{
    [SerializeField] private GradeData data;
    public GradeData Data { get => data; }
    [SerializeField] private string[] grades = new string[5];
    [SerializeField] private int[] golds = new int[5];

    public string CalculateGrade(int score, out int gold)
    {
        string grade = string.Empty;
        gold = 0;

        for (int i = 0; i < grades.Length; i++)
        {
            if (data.ScoreCriteria[i] - score <= 0)
            {
                grade = grades[i];
                gold = golds[i];
                break;
            }
        }

        return grade;
    }

    public string CalculateGrade(int score, out int gold, out int reverseScore)
    {
        string grade = string.Empty;
        gold = 0;
        reverseScore = 0;

        for (int i = 0; i < grades.Length; i++)
        {
            if (score - data.ScoreCriteria[i] <= 0)
            {
                grade = grades[i];
                gold = golds[i];
                reverseScore = data.ScoreCriteria[grades.Length - 1 - i];
                break;
            }
        }

        return grade;
    }
}
