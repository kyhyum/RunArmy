using UnityEngine;

public class GameManager : MonoBehaviour
{
    public PlayerSO playerData;

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
}
