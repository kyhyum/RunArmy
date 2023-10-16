using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameButtonManager : MonoBehaviour
{
    public Player player;
    [SerializeField] private Button leftButton;
    [SerializeField] private Button rightButton;
    [SerializeField] private Button forwardButton;

    private void Awake()
    {
        leftButton.onClick.AddListener(() => player.UpStair(PlayerRotate.left));
        rightButton.onClick.AddListener(() => player.UpStair(PlayerRotate.right));
        forwardButton.onClick.AddListener(() => player.UpStair(PlayerRotate.forward));
    }
}
