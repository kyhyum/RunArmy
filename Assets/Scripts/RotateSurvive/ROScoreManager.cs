using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ROScoreManager : MonoBehaviour
{
    public static ROScoreManager Instance { get; private set; }

    [SerializeField] private TMP_Text scoreText;
    private int score = 0;

    private bool gameEnded = false;

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

    public void IncreaseScore(int points)
    {
        if (!gameEnded)
        {
            score += points;
            scoreText.text = score.ToString();
        }
    }

    public void SetGameEnded()
    {
        gameEnded = true;
    }

    public int GetScore()
    {
        return score;
    }
}
