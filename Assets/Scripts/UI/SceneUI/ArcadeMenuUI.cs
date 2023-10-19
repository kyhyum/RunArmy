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
        goingUpBtn.onClick.AddListener(() => SceneLoadManager.Instance.LoadScene(MiniGame.GoingUp));
        packManBtn.onClick.AddListener(() => SceneLoadManager.Instance.LoadScene(MiniGame.packmanGameScene));
        clockJumpBtn.onClick.AddListener(() => SceneLoadManager.Instance.LoadScene(MiniGame.RotateGame));
        rainDropBtn.onClick.AddListener(() => SceneLoadManager.Instance.LoadScene(MiniGame.ParkStageScene));
        infinityStairsBtn.onClick.AddListener(() => SceneLoadManager.Instance.LoadScene(MiniGame.InfiniteStairScene));
        memoryBtn.onClick.AddListener(() => SceneLoadManager.Instance.LoadScene(MiniGame.MemoryGame));
        shootingBtn.onClick.AddListener(() => SceneLoadManager.Instance.LoadScene(MiniGame.ParkStageScene2));
        returnBtn.onClick.AddListener(() => SceneLoadManager.Instance.LoadScene(SceneType.MainMenuScene));
    }

    private void OnDestroy()
    {
        goingUpBtn.onClick.RemoveListener(() => SceneLoadManager.Instance.LoadScene(MiniGame.GoingUp));
        packManBtn.onClick.RemoveListener(() => SceneLoadManager.Instance.LoadScene(MiniGame.packmanGameScene));
        clockJumpBtn.onClick.RemoveListener(() => SceneLoadManager.Instance.LoadScene(MiniGame.RotateGame));
        rainDropBtn.onClick.RemoveListener(() => SceneLoadManager.Instance.LoadScene(MiniGame.ParkStageScene));
        infinityStairsBtn.onClick.RemoveListener(() => SceneLoadManager.Instance.LoadScene(MiniGame.InfiniteStairScene));
        memoryBtn.onClick.RemoveListener(() => SceneLoadManager.Instance.LoadScene(MiniGame.MemoryGame));
        shootingBtn.onClick.RemoveListener(() => SceneLoadManager.Instance.LoadScene(MiniGame.ParkStageScene2));
        returnBtn.onClick.RemoveListener(() => SceneLoadManager.Instance.LoadScene(SceneType.MainMenuScene));
    }


}
