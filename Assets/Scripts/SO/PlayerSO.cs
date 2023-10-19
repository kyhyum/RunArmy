using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "PlayerData", menuName = "Game/PlayerSO")]
public class PlayerSO : ScriptableObject
{
    public int coins;
    public List<SkinSO> purchasedSkins = new List<SkinSO>();

    public void AddCoins(int amount)
    {
        coins += amount;
    }

    public bool IsSkinPurchased(SkinSO skin)
    {
        return purchasedSkins.Contains(skin);
    }

    public void PurchaseSkin(SkinSO skin)
    {
        if (coins >= skin.price && !IsSkinPurchased(skin))
        {
            coins -= skin.price;
            purchasedSkins.Add(skin);
        }
    }
}
