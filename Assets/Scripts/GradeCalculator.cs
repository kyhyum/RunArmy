using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SceneType
{

}

public class GradeCalculator : MonoBehaviour
{
    [SerializeField] private GradeData data;

    [SerializeField] private string[] grades = new string[5];
    [SerializeField] private int[] golds = new int[5];

    public void CalculateGrade(SceneType scene, int score)
    {
        string grade = string.Empty;

        for (int i = 0; i < grades.Length; i++)
        {
            if (data.ScoreCriteria[i] - score <= 0)
            {
                grade = grades[i];
                break;
            }
        }

        PlayerPrefs.SetInt(scene.ToString(), score);
    }
}
