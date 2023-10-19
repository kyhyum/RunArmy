using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum SceneType
{
    StartScene,
    LoadingScene,
    MainMenuScene,
    ArcadeMenuScene,
    ShopScene,
    juchan_endingScene,
}

public enum MiniGame
{
    None,
    packmanGameScene,
    RotateGame,
    MemoryGame,
    ParkStageScene,
    ParkStageScene2,
    GoingUp,
    InfiniteStairScene,
}

public class SceneLoadManager : MonoBehaviour
{
    private static SceneLoadManager _instance;
    public static SceneLoadManager Instance { get => _instance; }

    private Queue<MiniGame> _miniGames = new Queue<MiniGame>();

    public bool IsStoryMode { get; private set; } = false;

    public MiniGame CurrentMiniGame = MiniGame.None;

    public int ClearCount { get; set; } = 0;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void InitMiniGames()
    {
        _miniGames.Clear();

        List<MiniGame> miniGames = new List<MiniGame>((MiniGame[])Enum.GetValues(typeof(MiniGame)));
        miniGames.Remove(MiniGame.None);
        int count = miniGames.Count;

        for (int i = 0; i < count; i++)
        {
            int index = UnityEngine.Random.Range(0, miniGames.Count);
            _miniGames.Enqueue(miniGames[index]);
            miniGames.RemoveAt(index);
        }
    }

    public void LoadNextStoryScene()
    {
        if (IsStoryMode)
        {
            if (_miniGames.Count == 0)
            {
                LoadScene(SceneType.juchan_endingScene);
                return;
            }

            MiniGame miniGame = _miniGames.Dequeue();
            CurrentMiniGame = miniGame;
            LoadScene(miniGame);
        }
        else
        {
            InitMiniGames();
            IsStoryMode = true;
            LoadNextStoryScene();
        }
    }

    public void LoadScene(SceneType scene)
    {
        LoadingBar.LoadScene(scene.ToString());
    }

    public void LoadScene(MiniGame miniGame)
    {
        LoadingBar.LoadScene(miniGame.ToString());
    }

    public void ToMain()
    {
        LoadScene(SceneType.MainMenuScene);
    }
    public void ToArcade()
    {
        IsStoryMode = false;
        LoadScene(SceneType.ArcadeMenuScene);
    }

}
