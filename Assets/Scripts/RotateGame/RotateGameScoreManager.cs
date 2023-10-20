using TMPro;
using UnityEngine;

public class RotateGameScoreManager : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text bestScoreText;

    public GradeCalculator gradeCalculator;

    public int score = 0;

    private void Start()
    {
        int bestScore = PlayerDataManager.Instance.LoadBestScore(MiniGame.RotateGame);
        bestScoreText.text = "Best Score: " + bestScore.ToString();
        SoundManager.Instance.PlayBGM(BGM.MiniGameBGM1);
    }

    public void IncreaseScore(int points)
    {
        score += points;
        scoreText.text = score.ToString();
        PlayerDataManager.Instance.SaveBestScore(MiniGame.RotateGame, score);
    }
}
