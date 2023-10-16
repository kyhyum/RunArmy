using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Skybox
{
    Sunset,
    Morning,
    Day,
    Night
}

public class SkyBoxSetting : MonoBehaviour
{
    public Material Sunset;
    public Material Morning;
    public Material Day;
    public Material Night;

    public void SetSkyBox(Skybox skybox)
    {
        switch (skybox)
        {
            case Skybox.Sunset:
                RenderSettings.skybox = Sunset;
                break;
            case Skybox.Morning:
                RenderSettings.skybox = Morning;
                break;
            case Skybox.Day:
                RenderSettings.skybox = Day;
                break;
            case Skybox.Night:
                RenderSettings.skybox = Day;
                break;
        }
    }

}
