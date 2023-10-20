using TMPro;
using UnityEngine;

public class HighScoreUI : MonoBehaviour
{
    [SerializeField] private TMP_Text memoryGameBestScoreText;
    [SerializeField] private TMP_Text rotateGameBestScoreText;
    [SerializeField] private TMP_Text packmanGameBestScoreText;
    [SerializeField] private TMP_Text GoingUpGameBestScoreText;
    [SerializeField] private TMP_Text ParkStageGameBestScoreText;
    [SerializeField] private TMP_Text infiniteStairGameBestScoreText;
    [SerializeField] private TMP_Text ParkStageScene2StairGameBestScoreText;

    private void Start()
    {
        UpdateBestScoreText(memoryGameBestScoreText, MiniGame.MemoryGame);
        UpdateBestScoreText(rotateGameBestScoreText, MiniGame.RotateGame);
        UpdateBestScoreText(infiniteStairGameBestScoreText, MiniGame.InfiniteStairScene);
        UpdateBestScoreText(GoingUpGameBestScoreText, MiniGame.GoingUp);
        UpdateBestScoreText(packmanGameBestScoreText, MiniGame.packmanGameScene);
        UpdateBestScoreText(ParkStageGameBestScoreText, MiniGame.ParkStageScene);
        UpdateBestScoreText(ParkStageScene2StairGameBestScoreText, MiniGame.ParkStageScene2);
    }

    void UpdateBestScoreText(TMP_Text textComponent, MiniGame game)
    {
        textComponent.text = "최고점수: " + PlayerDataManager.Instance.LoadBestScore(game).ToString();
    }
}
