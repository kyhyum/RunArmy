using UnityEngine;

public class RewardManager : MonoBehaviour
{
    public static RewardManager Instance { get; private set; }

    [SerializeField] private PlayerSO playerData;

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

    public void EndGame(int score)
    {
        int reward = CalculateReward(score);

        playerData.AddCoins(reward);
    }

    private int CalculateReward(int score)
    {
        if (score <= 5) return 1000;
        if (score <= 10) return 500;
        if (score <= 20) return 1000;

        return 20;
    }
}
