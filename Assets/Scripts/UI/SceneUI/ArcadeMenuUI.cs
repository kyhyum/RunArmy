using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArcadeMenuUI : MonoBehaviour
{
    [SerializeField] private Button goingUpBtn;
    [SerializeField] private Button packManBtn;
    [SerializeField] private Button clockJumpBtn;
    [SerializeField] private Button rainDropBtn;
    [SerializeField] private Button infinityStairsBtn;
    [SerializeField] private Button memoryBtn;
    [SerializeField] private Button shootingBtn;
    [SerializeField] private Button returnBtn;
    void Start()
    {
        goingUpBtn.onClick.AddListener(() => SceneLoadManager.Instance.LoadScene(MiniGame.GoingUp.ToString()));
        packManBtn.onClick.AddListener(() => SceneLoadManager.Instance.LoadScene(MiniGame.packmanGameScene.ToString()));
        clockJumpBtn.onClick.AddListener(() => SceneLoadManager.Instance.LoadScene(MiniGame.RotateGame.ToString()));
        rainDropBtn.onClick.AddListener(() => SceneLoadManager.Instance.LoadScene(MiniGame.ParkStageScene.ToString()));
        infinityStairsBtn.onClick.AddListener(() => SceneLoadManager.Instance.LoadScene(MiniGame.InfiniteStairScene.ToString()));
        memoryBtn.onClick.AddListener(() => SceneLoadManager.Instance.LoadScene(MiniGame.MemoryGame.ToString()));
        shootingBtn.onClick.AddListener(() => SceneLoadManager.Instance.LoadScene(MiniGame.ParkStageScene2.ToString()));
        returnBtn.onClick.AddListener(() => SceneLoadManager.Instance.LoadScene(SceneType.MainMenuScene));
    }

    private void OnDestroy()
    {
        goingUpBtn.onClick.RemoveListener(() => SceneLoadManager.Instance.LoadScene(MiniGame.GoingUp.ToString()));
        packManBtn.onClick.RemoveListener(() => SceneLoadManager.Instance.LoadScene(MiniGame.packmanGameScene.ToString()));
        clockJumpBtn.onClick.RemoveListener(() => SceneLoadManager.Instance.LoadScene(MiniGame.RotateGame.ToString()));
        rainDropBtn.onClick.RemoveListener(() => SceneLoadManager.Instance.LoadScene(MiniGame.ParkStageScene.ToString()));
        infinityStairsBtn.onClick.RemoveListener(() => SceneLoadManager.Instance.LoadScene(MiniGame.InfiniteStairScene.ToString()));
        memoryBtn.onClick.RemoveListener(() => SceneLoadManager.Instance.LoadScene(MiniGame.MemoryGame.ToString()));
        shootingBtn.onClick.RemoveListener(() => SceneLoadManager.Instance.LoadScene(MiniGame.ParkStageScene2.ToString()));
        returnBtn.onClick.RemoveListener(() => SceneLoadManager.Instance.LoadScene(SceneType.MainMenuScene));
    }


}
