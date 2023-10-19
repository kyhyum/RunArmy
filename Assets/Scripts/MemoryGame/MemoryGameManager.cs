using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MemoryGameManager : MonoBehaviour
{
    [SerializeField] private Sprite normalSprite;
    [SerializeField] private Sprite highlightSprite;
    [SerializeField] private List<Button> clickableButtons;
    [SerializeField] private CanvasGroup buttons;
    [SerializeField] private Button startButton;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TMP_Text bestScoreText;

    private List<int> playerTaskList = new List<int>();
    private List<int> playerSequenceList = new List<int>();

    private float highlightDuration = 0.1f;
    private int score = 0;

    private void Awake()
    {
        

        ResetButtonImages();
        UpdateUI();
    }

    public void AddToPlayerSequenceList(int buttonID)
    {
        playerSequenceList.Add(buttonID);
        StartCoroutine(HighlightButton(buttonID));

        int minLength = Mathf.Min(playerTaskList.Count, playerSequenceList.Count);
        for (int i = 0; i < minLength; i++)
        {
            if (playerTaskList[i] != playerSequenceList[i])
            {
                StartCoroutine(PlayerLost());
                return;
            }
        }

        if (playerSequenceList.Count == playerTaskList.Count)
        {
            ScoreRound();
            StartCoroutine(StartNextRound());
        }
    }

    private void ScoreRound()
    {
        score++;
        UpdateUI();
    }

    private void UpdateUI()
    {
        scoreText.text = score.ToString();
    }

    private IEnumerator HighlightButton(int buttonID)
    {
        clickableButtons[buttonID].image.sprite = highlightSprite;
        yield return new WaitForSeconds(highlightDuration);
        clickableButtons[buttonID].image.sprite = normalSprite;
        yield return new WaitForSeconds(1f);
    }

    private IEnumerator PlayerLost()
    {
        playerSequenceList.Clear();
        playerTaskList.Clear();
        yield return new WaitForSeconds(2f);

        PlayerDataManager.Instance.SaveBestScore(MiniGame.MemoryGame, score);

        startButton.gameObject.SetActive(true);
        buttons.interactable = false;
    }

    private IEnumerator StartNextRound()
    {
        playerSequenceList.Clear();
        buttons.interactable = false;
        yield return new WaitForSeconds(1f);

        int newPattern = Random.Range(0, 4);
        playerTaskList.Add(newPattern);

        for (int i = 0; i < playerTaskList.Count; i++)
        {
            int index = playerTaskList[i];
            yield return StartCoroutine(HighlightButton(index));
        }

        buttons.interactable = true;
    }

    private void ResetButtonImages()
    {
        foreach (var button in clickableButtons)
        {
            button.image.sprite = normalSprite;
        }
    }

    public void StartGame()
    {
        int bestScore = PlayerDataManager.Instance.LoadBestScore(MiniGame.MemoryGame);
        bestScoreText.text = "Best Score: " + bestScore.ToString();
        score = 0;
        UpdateUI();
        StartCoroutine(StartNextRound());
        startButton.gameObject.SetActive(false);
    }
}
