using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPurchase : MonoBehaviour
{
    public PlayerSO playerData;

    public void AddCoins(int amount)
    {
        playerData.coins += amount;
    }

    public bool IsSkinPurchased(SkinSO skin)
    {
        return playerData.purchasedSkins.Contains(skin);
    }

    public void PurchaseSkin(SkinSO skin)
    {
        if (playerData.coins >= skin.price && !IsSkinPurchased(skin))
        {
            playerData.coins -= skin.price;
            playerData.purchasedSkins.Add(skin);
        }
    }
}
