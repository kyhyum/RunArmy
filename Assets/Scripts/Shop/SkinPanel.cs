using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SkinPanel : MonoBehaviour
{
    public SkinSO skinInfo;
    //public TMP_Text skinNameText;
    //public TMP_Text priceText;
    public TMP_Text buttonText;

    public PlayerSO playerData;

    private void Start()
    {
        UpdateSkinInfo();
    }

    public void UpdateSkinInfo()
    {
        //skinNameText.text = skinInfo.skinName;
        //priceText.text = "АЁАн: " + skinInfo.price;
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
            UpdateButtonText();
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
            buttonText.text = "BUY";
        }
    }

    private void TryPurchaseSkin()
    {
        if (playerData.coins >= skinInfo.price && skinInfo.locked)
        {
            playerData.coins -= skinInfo.price;
            skinInfo.locked = false;
            UpdateSkinInfo();
        }
    }
}
