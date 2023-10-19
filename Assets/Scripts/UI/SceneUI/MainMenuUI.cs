using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField] private Button arcadeBtn;
    [SerializeField] private Button storyBtn;
    [SerializeField] private Button shopBtn;

    private void Start()
    {
        arcadeBtn.onClick.AddListener(() => SceneLoadManager.Instance.ToArcade());
        storyBtn.onClick.AddListener(() => SceneLoadManager.Instance.LoadNextStoryScene());
        shopBtn.onClick.AddListener(() => SceneLoadManager.Instance.ToShop());
    }

    private void OnDestroy()
    {
        arcadeBtn.onClick.RemoveListener(() => SceneLoadManager.Instance.ToArcade());
        storyBtn.onClick.RemoveListener(() => SceneLoadManager.Instance.LoadNextStoryScene());
        shopBtn.onClick.RemoveListener(() => SceneLoadManager.Instance.ToShop());
    }
}
