using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class InfiniteStairGameManager : MonoBehaviour
{
    public static InfiniteStairGameManager Instance;

    public int count = 0;
    private int skyBoxCount = 0;

    public int healthMinus = 1;
    private float elapsedTime = 0;
    
    public StairSpawn stairSpawn;
    public SkyBoxSetting skyBoxSetting;
    
    private Vector3 currentStairTr = new Vector3(0.5f, 0.05f, 0.5f);
    List<Vector3> upStairPos = new List<Vector3>();

    //UI
    public Slider healthSlider;
    public TextMeshProUGUI scoreTxt;

    private void Awake()
    {
        Instance = this;
        healthSlider.value = 50;
        //upStairPos 초기화
        upStairPos.Add(new Vector3(1f, 0.6f, 0f));
        upStairPos.Add(new Vector3(0f, 0.6f, 1f));
        upStairPos.Add(new Vector3(-1f, 0.6f, 0f));
    }

    private void Update()
    {
        elapsedTime += Time.deltaTime;
        if(elapsedTime > 1f)
        {
            healthSlider.value -= healthMinus;
            elapsedTime = 0f;
        }
    }

    private void Start()
    {
        for (int i = 0; i< 10; i++)
        {
            SpawnStair();
        }
    }

    //계단 스폰
    public void SpawnStair()
    {
        GameObject spawnStair = stairSpawn.GetQueue();
        spawnStair.transform.position = SetSpawnStairPosition();
    }

    private Vector3 SetSpawnStairPosition()
    {
        currentStairTr += upStairPos[Random.Range(0, 2)];
        return currentStairTr;
    }

    public void GameOver()
    {

    }

    public void Success()
    {
        healthSlider.value += 5;
        scoreTxt.text = count.ToString();
        if(count % 50 == 0)
        {
            int num = skyBoxCount % 4;
            skyBoxSetting.SetSkyBox(Skybox.Sunset);
        }
    }
}
