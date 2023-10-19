using TMPro;
using UnityEngine;

public class RotateGameScoreManager : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text bestScoreText;

    private int score = 0;

    private void Start()
    {
        int bestScore = PlayerDataManager.Instance.LoadBestScore(SceneType.RotateGame);
        bestScoreText.text = "Best Score: " + bestScore.ToString();
    }

    public void IncreaseScore(int points)
    {
        score += points;
        scoreText.text = score.ToString();
        PlayerDataManager.Instance.SaveBestScore(SceneType.RotateGame, score);
    }
}
