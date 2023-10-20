using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HighScoreUI : MonoBehaviour
{
    [SerializeField] private TMP_Text memoryGameBestScoreText;
    [SerializeField] private TMP_Text rotateGameBestScoreText;
    [SerializeField] private TMP_Text goingUpBestScoreText;
    [SerializeField] private TMP_Text packManBestScoreText;
    [SerializeField] private TMP_Text rainDropScoreText;
    [SerializeField] private TMP_Text infinityStairsBestScoreText;
    [SerializeField] private TMP_Text shootingBestScoreText;

    private void Start()
    {
        UpdateBestScoreText(memoryGameBestScoreText, MiniGame.MemoryGame);
        UpdateBestScoreText(rotateGameBestScoreText, MiniGame.RotateGame);
        UpdateBestScoreText(goingUpBestScoreText, MiniGame.GoingUp);
        UpdateBestScoreText(packManBestScoreText, MiniGame.packmanGameScene);
        UpdateBestScoreText(rainDropScoreText, MiniGame.ParkStageScene);
        UpdateBestScoreText(infinityStairsBestScoreText, MiniGame.InfiniteStairScene);
        UpdateBestScoreText(shootingBestScoreText, MiniGame.ParkStageScene2);
    }

    void UpdateBestScoreText(TMP_Text textComponent, MiniGame game)
    {
        textComponent.text = "최고점수: " + PlayerDataManager.Instance.LoadBestScore(game).ToString();
    }
}
