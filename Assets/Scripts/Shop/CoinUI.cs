using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinUI : MonoBehaviour
{
    public PlayerSO playerData;
    public TMP_Text goldText;

    private void Update()
    {
        goldText.text = "Coin: " + playerData.coins.ToString();
    }
}
