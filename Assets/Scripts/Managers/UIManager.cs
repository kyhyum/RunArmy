using System.Collections.Generic;
using UnityEngine;

public class UIManager
{
    private static UIManager _instance;
    private Dictionary<string, GameObject> popUpDic = new Dictionary<string, GameObject>();
    public static UIManager Instance
    {
        get
        {
            if (_instance == null)
                _instance = new UIManager();
            return _instance;
        }
    }

    public void ClearPopUpDic()
    {
        popUpDic.Clear();
    }

    public UIPopup ShowPopup(string popupname)
    {
        if (popUpDic.ContainsKey(popupname))
        {
            Debug.Log("containKey");
            return ShowPopupWithSceneObject(popupname);
        }
        else
        {
            Debug.Log("!!containKey");
            var obj = Resources.Load("Popups/" + popupname, typeof(GameObject)) as GameObject;
            if (!obj)
            {
                Debug.LogWarning("Failed to ShowPopup" + popupname);
                return null;
            }
            return ShowPopupWithPrefab(obj, popupname);
        }
    }

    public T ShowPopup<T>() where T : UIPopup
    {
        return ShowPopup(typeof(T).Name) as T;
    }

    public UIPopup ShowPopupWithPrefab(GameObject prefab, string popupName)
    {
        var obj = UnityEngine.Object.Instantiate(prefab);
        popUpDic.Add(popupName, obj);
        obj.transform.SetParent(InfiniteStairGameManager.Instance.canvasTr, false);
        return ShowPopup(obj, popupName);
    }

    public UIPopup ShowPopupWithSceneObject(string popupName)
    {
        var obj = popUpDic[popupName];
        var popup = obj.GetComponent<UIPopup>();
        popup.Refresh();
        obj.SetActive(true);
        return popup;
    }

    public UIPopup ShowPopup(GameObject obj, string popupname)
    {
        var popup = obj.GetComponent<UIPopup>();

        obj.SetActive(true);
        return popup;
    }

    public UIPopup ClosePopup(GameObject obj)
    {
        var popup = obj.GetComponent<UIPopup>();
        obj.SetActive(false);
        return popup;
    }
}