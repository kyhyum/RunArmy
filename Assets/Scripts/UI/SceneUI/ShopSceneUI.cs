using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopSceneUI : MonoBehaviour
{
    [SerializeField] private Button returnBtn;
    void Start()
    {
        returnBtn.onClick.AddListener(() => SceneLoadManager.Instance.LoadScene(SceneType.MainMenuScene));
    }

    private void OnDestroy()
    {
        returnBtn.onClick.RemoveListener(() => SceneLoadManager.Instance.LoadScene(SceneType.MainMenuScene));
    }


}
