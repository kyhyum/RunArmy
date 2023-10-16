using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public enum PlayerRotate
{
    left,
    right,
    forward
}

public class Player : MonoBehaviour
{
    private Vector3 InitialPosition;
    [field: SerializeField] public StairAnimationData AnimationData { get; private set; }
    [SerializeField]public Animator animator { get; private set; }

    public Transform PlayerTr;
    private void Awake()
    {
        AnimationData.Initialize();
        InitialPosition = transform.position;
        animator = GetComponentInChildren<Animator>();
    }

    //계단 올라가는 함수
    public void UpStair(PlayerRotate playerRotate)
    {
        SetPlayerRotate(playerRotate);
        transform.position = InitialPosition;
        PlayerTr.position = InitialPosition;
        StartAnimation();
        MoveStair(playerRotate);
        CheckForCollision();
        if (InfiniteStairGameManager.Instance.IsSuccess())
        {
            if (InfiniteStairGameManager.Instance.count % 20 == 0 && InfiniteStairGameManager.Instance.healthMinus <= 20)
            {
                InfiniteStairGameManager.Instance.healthMinus += 1;
            }
            InfiniteStairGameManager.Instance.Success();
        }
        else
        {
            InfiniteStairGameManager.Instance.GameOver();
        }
    }

    //성공을 했는지 확인을 위한 CollisionCheck
    private void CheckForCollision()
    {
        if (Physics.Raycast(transform.position - Vector3.down * 0.2f, transform.forward, out RaycastHit hit, 1f))
        {
            InfiniteStairGameManager.Instance.isSuccess = true;
        }
    }

    //플레이어 회전 값 설정
    public void SetPlayerRotate(PlayerRotate playerRotate)
    {
        if(playerRotate == PlayerRotate.left)
        {
            this.gameObject.transform.rotation = Quaternion.Euler(new Vector3(0, -90f, 0));
        }
        else if(playerRotate == PlayerRotate.right)
        {
            this.gameObject.transform.rotation = Quaternion.Euler(new Vector3(0, 90f, 0));
        }
        else if(playerRotate == PlayerRotate.forward) 
        {
            this.gameObject.transform.rotation = Quaternion.Euler(new Vector3(0, 0f, 0));
        }
    }

    //플레이어 에니메이션 설정
    private void StartAnimation()
    {
        if(InfiniteStairGameManager.Instance.count == 0)
        {
            animator.SetBool(AnimationData.StartGameParameterHash, true);
        }
        else if(InfiniteStairGameManager.Instance.count % 2 == 0)
        {
            animator.SetBool(AnimationData.LeftLegUpParameterHash, true);
            animator.SetBool(AnimationData.RightLegUpParameterHash, false);
        }
        else if(InfiniteStairGameManager.Instance.count % 2 != 0)
        {
            animator.SetBool(AnimationData.LeftLegUpParameterHash, false);
            animator.SetBool(AnimationData.RightLegUpParameterHash, true);
        }
    }

    //계단 올라갈때 위치 조정
    private void MoveStair(PlayerRotate playerRotate)
    {
        if (playerRotate == PlayerRotate.left)
        {
            InitialPosition += new Vector3(-1f, 0.6f, 0f);
        }
        else if (playerRotate == PlayerRotate.right)
        {
            InitialPosition += new Vector3(1f, 0.6f, 0f);
        }
        else if (playerRotate == PlayerRotate.forward)
        {
            InitialPosition += new Vector3(0f, 0.6f, 1f);
        }
    }
}
