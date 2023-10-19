using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SkinPanel : MonoBehaviour
{
    public SkinSO skinInfo;
    public TMP_Text buttonText;
    public PlayerDataController playerDataController;

    private void Start()
    {
        UpdateSkinInfo();
        skinInfo.locked = !playerDataController.IsSkinPurchased(skinInfo);
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
            if (playerDataController.IsSkinPurchased(skinInfo))
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
        if (playerDataController.playerData.coins >= skinInfo.price && !playerDataController.IsSkinPurchased(skinInfo))
        {
            playerDataController.PurchaseSkin(skinInfo);
            UpdateSkinInfo();
        }
    }
}
