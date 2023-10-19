using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SkinPanel : MonoBehaviour
{
    public SkinSO skinInfo;
    public TMP_Text buttonText;
    public PlayerSO playerData;

    private void Start()
    {
        UpdateSkinInfo();
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
            if (playerData.IsSkinPurchased(skinInfo))
            {
                buttonText.text = "EQUIP";
                skinInfo.locked = false;
            }
            else
            {
                buttonText.text = "BUY " + skinInfo.price + "G";
            }
        }
    }

    private void TryPurchaseSkin()
    {
        if (playerData.coins >= skinInfo.price && !playerData.IsSkinPurchased(skinInfo))
        {
            playerData.PurchaseSkin(skinInfo);
            UpdateSkinInfo();
        }
    }
}
