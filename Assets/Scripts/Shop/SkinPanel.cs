using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SkinPanel : MonoBehaviour
{
    public SkinSO skinInfo;
    public TMP_Text buttonText;
    public PlayerPurchase playerPurchase;

    private void Start()
    {
        UpdateSkinInfo();
        skinInfo.locked = !playerPurchase.IsSkinPurchased(skinInfo);
    }

    public void UpdateSkinInfo()
    {
        UpdateButtonText();
    }

    public void EquipSkin()
    {
        if (!skinInfo.locked)
        {
            SkinLoadController.skinToLoad = skinInfo.skinPrefab;
        }
        else
        {
            TryPurchaseSkin();
        }
    }

    private void UpdateButtonText()
    {
        if (!skinInfo.locked)
        {
            buttonText.text = "EQUIP";
        }
        else
        {
            if (playerPurchase.IsSkinPurchased(skinInfo))
            {
                buttonText.text = "EQUIP";
                skinInfo.locked = false;
            }
            else
            {
                buttonText.text = "BUY [" + skinInfo.price + "G]";
            }
        }
    }

    private void TryPurchaseSkin()
    {
        if (playerPurchase.playerData.coins >= skinInfo.price && !playerPurchase.IsSkinPurchased(skinInfo))
        {
            playerPurchase.PurchaseSkin(skinInfo);
            UpdateSkinInfo();
        }
    }
}
