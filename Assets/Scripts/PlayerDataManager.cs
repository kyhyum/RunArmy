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
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        LoadPlayerData();
        SavePlayerData();
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

    public void SaveBestScore(MiniGame scene, int score, bool reverse = false)
    {
        int currentBestScore = 0;

        if (reverse)
        {
            currentBestScore = PlayerPrefs.GetInt(scene.ToString() + "_ShotestTime", 0);
            if (score < currentBestScore)
            {
                PlayerPrefs.SetInt(scene.ToString() + "_ShotestTime", score);
                PlayerPrefs.Save();
            }
        }
        else
        {
            currentBestScore = PlayerPrefs.GetInt(scene.ToString() + "_BestScore", 0);
            if (score > currentBestScore)
            {
                PlayerPrefs.SetInt(scene.ToString() + "_BestScore", score);
                PlayerPrefs.Save();
            }
        }

    }

    public int LoadBestScore(MiniGame scene)
    {
        return PlayerPrefs.GetInt(scene.ToString() + "_BestScore", 0);
    }

    public void ResetData()
    {
        PlayerPrefs.DeleteAll();
    }
}
