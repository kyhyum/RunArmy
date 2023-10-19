using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GoingUpUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timeText;
    private GameObject resultUI;

    public void ShowElapsedTime(float time)
    {
        timeText.text = time.ToString("F2");
    }
}
