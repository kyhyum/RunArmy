using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Loading;
using UnityEngine;
using UnityEngine.UI;

public class UIPopup: MonoBehaviour
{
    [SerializeField] private TMP_Text txtTitle;
    [SerializeField] private Button backButton;

    [SerializeField] private Button confirmButton;
    [SerializeField] private TMP_Text confirmButtonTxt;

    [SerializeField] private Button cancelButton;
    [SerializeField] private TMP_Text cancelButtonTxt;

    public bool animated = false;

    private Action OnConfirm;
    private Action onClose;
    [SerializeField] private GameObject contents;

    public virtual void Start()
    {
        confirmButton.onClick.AddListener(Confirm);
        backButton.onClick.AddListener(Close);
        cancelButton.onClick.AddListener(Leave);
        Refresh();
        PlayShowAnimation();
    }

    public void PlayShowAnimation()
    {
        if(animated && contents)
        {
            contents.transform.localScale = Vector3.one * 0.8f;
            contents.transform.DOScale(Vector3.one, 0.25f).SetEase(Ease.OutBack);
        }
    }

    public virtual void Refresh()
    {

    }

    public void SetPopup(string title, string confirmButtonTxt, string cancelButtonTxt, Action onConfirm = null, Action onClose = null)
    {
        txtTitle.text = title;
        this.confirmButtonTxt.text = confirmButtonTxt;
        this.cancelButtonTxt.text = cancelButtonTxt;
        SetPopup(onConfirm, onClose);
    }

    public void SetPopup(Action onConfirm, Action onClose)
    {
        this.OnConfirm = onConfirm;
        this.onClose = onClose;
    }

    void Confirm()
    {
        if(OnConfirm != null)
        {
            OnConfirm();
            OnConfirm = null;
        }

        Close();
    }

    void Close()
    {
        UIManager.Instance.ClosePopup(this.gameObject);
    }

    void Leave()
    {
        if (onClose != null)
        {
            onClose();
            onClose = null;
        }
        Close();
    }
}
