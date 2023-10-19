using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GoingUpUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timeText;

    void Start()
    {
        
    }

    void Update()
    {
        timeText.text = Time.time.ToString("F2");
    }
}
