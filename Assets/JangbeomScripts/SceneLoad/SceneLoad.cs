using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneLoad : MonoBehaviour
{
    public void ToMain()
    {
        LoadingBar.LoadScene("MainMenuScene");
    }
    public void ToArcade()
    {
        LoadingBar.LoadScene("ArcadeMenuscene");
    }
   
}