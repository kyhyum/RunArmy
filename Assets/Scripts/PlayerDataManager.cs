using UnityEngine;

public class PlayerDataManager : MonoBehaviour
{
    public PlayerSO playerData;

    public static PlayerDataManager Instance { get; private set; }

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

    private void Start()
    {
        LoadPlayerData();
    }

    private void OnApplicationQuit()
    {
        SavePlayerData();
    }

    private void LoadPlayerData()
    {
        if (PlayerPrefs.HasKey("Coins"))
        {
            playerData.coins = PlayerPrefs.GetInt("Coins");
        }
    }

    private void SavePlayerData()
    {
        PlayerPrefs.SetInt("Coins", playerData.coins);
        PlayerPrefs.Save();
    }

    public void SaveBestScore(MiniGame scene, int score)
    {
        int currentBestScore = PlayerPrefs.GetInt(scene.ToString() + "_BestScore", 0);
        if (score > currentBestScore)
        {
            PlayerPrefs.SetInt(scene.ToString() + "_BestScore", score);
            PlayerPrefs.Save();
        }
    }

    public int LoadBestScore(MiniGame scene)
    {
        return PlayerPrefs.GetInt(scene.ToString() + "_BestScore", 0);
    }
}
