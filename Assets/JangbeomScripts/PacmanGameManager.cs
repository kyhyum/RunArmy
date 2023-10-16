using TMPro;
using UnityEngine;

public class PacmanGameManager : MonoBehaviour
{
    public static PacmanGameManager Instance;

    private int score = 0;

    public TMP_Text scoreText; 

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void UpdateScoreText()
    {
        scoreText.text = " " + score;
    }

    public void IncreaseScore(int increment)
    {
        score += increment;
        UpdateScoreText();
    }
}
