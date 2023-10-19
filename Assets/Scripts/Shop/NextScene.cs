using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    public void LoadScene5()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(6);
    }
}
