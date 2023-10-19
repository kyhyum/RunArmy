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

    //���� �ߴ��� bool ����
    public bool isSuccess = false;
    //���� Ƚ��
    public int count = 0;

    //ü�� ����
    public int healthMinus = 1;
    private float elapsedTime = 0;

    //SKyBox ����
    public SkyBoxSetting skyBoxSetting;
    private int skyBoxCount = 0;

    //Stair Spawn ����
    public StairSpawn stairSpawn;
    public Queue<GameObject> stairSpawnQueue = new Queue<GameObject>();
    private Vector3 currentStairTr = new Vector3(0.5f, 0.05f, 0.5f);
    List<Vector3> upStairPos = new List<Vector3>();
    private int stairRangeNum = 1;

    //UI
    public Slider healthSlider;
    public TextMeshProUGUI scoreTxt;

    //Grade Calcuator
    public GradeCalculator gradeCalculator;
    private void Awake()
    {
        Instance = this;
        healthSlider.value = 50;
        //upStairPos �ʱ�ȭ
        upStairPos.Add(new Vector3(1f, 0.6f, 0f));
        upStairPos.Add(new Vector3(0f, 0.6f, 1f));
        upStairPos.Add(new Vector3(-1f, 0.6f, 0f));
    }

    private void Update()
    {
        elapsedTime += Time.deltaTime;
        if (elapsedTime > 1f && count > 0)
        {
            healthSlider.value -= healthMinus;
            elapsedTime = 0f;
        }

        if (healthSlider.value == 0)
        {
            GameOver();
        }
    }

    private void Start()
    {
        for (int i = 0; i < 30; i++)
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

    //��� ����
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

        //�����̵� ����� ���
        healthMinus = 0;
        {
            int gold = 0;
            string grade;
            Popup_Result popup = UIManager.Instance.ShowPopup<Popup_Result>();
            popup.SetPopup("���� ���", "�ٽ��ϱ�", "������", AcadeConfirm, AcadeClose);

            grade = gradeCalculator.CalculateGrade(count, out gold);
            popup.SetValue(count, gold, grade);
            if (count >= PlayerDataManager.Instance.LoadBestScore(MiniGame.InfiniteStairScene))
            {
                PlayerDataManager.Instance.SaveBestScore(MiniGame.InfiniteStairScene, count);
            }
        }
        //���丮 ����� ���
        //{
        //    Popup_StoryResult popup = UIManager.Instance.ShowPopup<Popup_StoryResult>();
        //    // ���� ���
        //    popup.SetPopup("���� ���", "���� ��������", "������", StoryConfirm, StoryClose);
        //    // �� ���� ���
        //    //popup.SetPopup("���� ���", "�ٽ� �ϱ�", "������", StoryConfirm, StoryClose);

        //    // Ŭ���� ���� Ȯ��
        //    popup.SetText(true);
        //}
    }
    public void AcadeConfirm()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("InfiniteStairScene");
        UIManager.Instance.ClearPopUpDic();
    }
    public void AcadeClose()
    {
        //TODO : �� �̵�
    }
    public void StoryConfirm()
    {
        //TODO : �� �̵�
    }

    public void StoryClose()
    {
        //TODO : �� �̵�
    }

    public void Success()
    {
        count++;
        healthSlider.value += 5;
        scoreTxt.text = count.ToString();
        if (count % 50 == 0)
        {
            int num = skyBoxCount % 4;
            skyBoxSetting.SetSkyBox((Skybox)num);
            skyBoxCount++;
        }
        if (count >= 7)
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

