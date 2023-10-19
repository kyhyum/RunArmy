using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HighScoreUI : MonoBehaviour
{
    [SerializeField] private TMP_Text memoryGameBestScoreText;
    [SerializeField] private TMP_Text rotateGameBestScoreText;

    private void Start()
    {
        UpdateBestScoreText(memoryGameBestScoreText, MiniGame.MemoryGame);
        UpdateBestScoreText(rotateGameBestScoreText, MiniGame.RotateGame);
    }

    void UpdateBestScoreText(TMP_Text textComponent, MiniGame game)
    {
        textComponent.text = "최고점수: " + PlayerDataManager.Instance.LoadBestScore(game).ToString();
    }
}
