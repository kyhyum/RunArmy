using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoingUp : MonoBehaviour
{
    [SerializeField] private GradeData data;

    private GoingUpUI _goingUpUI;

    private void Awake()
    {
        _goingUpUI = FindAnyObjectByType<GoingUpUI>();
    }

    void Start()
    {
        SoundManager.Instance.PlayBGM(BGM.GoingUp);
    }

    private void Update()
    {
        if (_goingUpUI != null)
        {
            _goingUpUI.ShowElapsedTime(Time.time);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // 너무 많이 호출될까봐 Layer Collision Matrix 처리 해줬음
        if (other.TryGetComponent(out CharacterController controller))
        {
            Clear(controller);
        }
    }

    private void Clear(CharacterController controller)
    {
        controller.enabled = false;
        SoundManager.Instance.StopBGM();
        // TODO
        // ShowPopup
    }
}
