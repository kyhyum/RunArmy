using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InfiniteStairGameManager : MonoBehaviour
{
    public static InfiniteStairGameManager Instance;

    //성공 했는지 bool 변수
    public bool isSuccess = false;
    //성공 횟수
    public int count = 0;

    //체력 관련
    public int healthMinus = 1;
    private float elapsedTime = 0;

    //SKyBox 설정
    public SkyBoxSetting skyBoxSetting;
    private int skyBoxCount = 0;

    //Stair Spawn 관련
    public StairSpawn stairSpawn;
    public Queue<GameObject> stairSpawnQueue = new Queue<GameObject>();
    private Vector3 currentStairTr = new Vector3(0.5f, 0.05f, 0.5f);
    List<Vector3> upStairPos = new List<Vector3>();
    private int stairRangeNum = 1;

    //UI
    public Slider healthSlider;
    public TextMeshProUGUI scoreTxt;

    //Grade Calcuator
    [SerializeField]private GradeCalculator gradeCalculator;

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
        if(elapsedTime > 1f && count > 0)
        {
            healthSlider.value -= healthMinus;
            elapsedTime = 0f;
        }

        if(healthSlider.value == 0)
        {
            GameOver();
        }
    }

    private void Start()
    {
        SoundManager.Instance.PlayBGM(BGM.MiniGameBGM4);

        for (int i = 0; i< 30; i++)
        {
            SpawnStair();
        }
    }

    public int RandomRangeStairList()
    {
        if (stairRangeNum == 0)
        {
            stairRangeNum = Random.Range(0, 2);
        }
        else if (stairRangeNum == 2)
        {
            stairRangeNum = Random.Range(1, 3);
        }
        else
        {
            stairRangeNum = Random.Range(0, 3);
        }
        return stairRangeNum;
    }

    //계단 스폰
    public void SpawnStair()
    {
        GameObject spawnStair = stairSpawn.GetQueue();
        spawnStair.transform.position = SetSpawnStairPosition();
        stairSpawnQueue.Enqueue(spawnStair);
    }

    private Vector3 SetSpawnStairPosition()
    {
        currentStairTr += upStairPos[RandomRangeStairList()];
        return currentStairTr;
    }

    public void GameOver()
    {
        int gold = 0;
        string grade;
        grade = gradeCalculator.CalculateGrade(count, out gold);
        healthMinus = 0;
        //아케이드 모드일 경우
        if (!SceneLoadManager.Instance.IsStoryMode)
        {
            Popup_Result popup = UIManager.Instance.ShowPopup<Popup_Result>();
            popup.SetPopup("게임 결과", "다시하기", "나가기", AcadeConfirm, () => SceneLoadManager.Instance.ToArcade());

            popup.SetValue(count, gold, grade);

            PlayerDataManager.Instance.SaveBestScore(MiniGame.InfiniteStairScene, count);
        }
        //스토리 모드일 경우
        else{
            Popup_StoryResult popup = UIManager.Instance.ShowPopup<Popup_StoryResult>();
            if(count >= gradeCalculator.Data.ScoreCriteria[2])
            {
                // 깻을 경우
                popup.SetPopup("게임 결과", "다음 스테이지", "나가기", StoryConfirmClear, StoryClose);
                popup.SetText(true);
            }
            else
            {
                // 못 꺴을 경우
                popup.SetPopup("게임 결과", "다시 하기", "나가기", StoryConfirmNotClear, StoryClose);
                popup.SetText(false);
            }
        }

        PlayerDataManager.Instance.playerData.AddCoins(gold);
    }
    public void AcadeConfirm()
    {
        SceneManager.LoadScene("InfiniteStairScene");
        UIManager.Instance.ClearPopUpDic();
    }
    public void AcadeClose()
    {
        SceneLoadManager.Instance.ToArcade();
    }
    public void StoryConfirmNotClear()
    {
        SceneLoadManager.Instance.LoadScene(SceneLoadManager.Instance.CurrentMiniGame);
    }
    public void StoryConfirmClear()
    {
        SceneLoadManager.Instance.LoadNextStoryScene();
    }

    public void StoryClose()
    {
        SceneLoadManager.Instance.LoadScene(SceneType.MainMenuScene);
    }

    public void Success()
    {
        count++;
        healthSlider.value += 5;
        scoreTxt.text = count.ToString();
        if(count % 50 == 0)
        {
            int num = skyBoxCount % 4;
            skyBoxSetting.SetSkyBox((Skybox)num);
            skyBoxCount++;
        }
        if(count >= 7)
        {
            stairSpawn.InsertQueue(stairSpawnQueue.Dequeue());
        }
        SpawnStair();
    }

    public bool IsSuccess()
    {
        bool temp = isSuccess;
        isSuccess = false;
        return temp;
    }
}
