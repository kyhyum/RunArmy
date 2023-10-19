using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField] private Button arcadeBtn;
    [SerializeField] private Button storyBtn;

    private void Start()
    {
        arcadeBtn.onClick.AddListener(() => SceneLoadManager.Instance.LoadScene(SceneType.ArcadeMenuScene));
        storyBtn.onClick.AddListener(() => SceneLoadManager.Instance.LoadNextStoryScene());
    }

    private void OnDestroy()
    {
        arcadeBtn.onClick.RemoveListener(() => SceneLoadManager.Instance.LoadScene(SceneType.ArcadeMenuScene));
        storyBtn.onClick.RemoveListener(() => SceneLoadManager.Instance.LoadNextStoryScene());
    }
}
