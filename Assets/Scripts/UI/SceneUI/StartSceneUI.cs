using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartSceneUI : MonoBehaviour
{
    [SerializeField] private Button startBtn;
    [SerializeField] private Button settingBtn;

    private void Start()
    {
        startBtn.onClick.AddListener(() => SceneLoadManager.Instance.LoadScene(SceneType.MainMenuScene));
    }

    private void OnDestroy()
    {
        startBtn.onClick.RemoveListener(() => SceneLoadManager.Instance.LoadScene(SceneType.MainMenuScene));
    }
}
