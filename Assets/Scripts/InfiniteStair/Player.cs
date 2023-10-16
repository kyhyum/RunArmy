using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public enum PlayerRotate
{
    left,
    right,
    forward
}

public class Player : MonoBehaviour
{
    private Transform mainCameraTransform { get; set; }
    private Vector3 InitialPosition;
    private InfiniteStairGameManager gameManager;
    [field: SerializeField] public StairAnimationData AnimationData { get; private set; }

    [SerializeField]public Animator animator { get; private set; }
    private void Awake()
    {
        gameManager = InfiniteStairGameManager.Instance;
        AnimationData.Initialize();
        InitialPosition = transform.position;
        animator = GetComponentInChildren<Animator>();
    }

    public void UpStair(PlayerRotate playerRotate)
    {
        SetPlayerRotate(playerRotate);
        transform.position = InitialPosition + this.transform.forward * 0.5f + this.transform.up * 0.3f;
        StartAnimation();
        gameManager.count++;
        if(gameManager.count % 20 == 0 || gameManager.healthMinus <= 20)
        {
            gameManager.healthMinus += 1;
        }
        MoveStair(playerRotate);
        gameManager.Success();
    }

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

    private void StartAnimation()
    {
        if(gameManager.count == 0)
        {
            animator.SetBool(AnimationData.StartGameParameterHash, true);
        }
        else if(gameManager.count % 2 != 0)
        {
            animator.SetBool(AnimationData.LeftLegUpParameterHash, true);
            animator.SetBool(AnimationData.RightLegUpParameterHash, false);
        }
        else if(gameManager.count % 2 == 0)
        {
            animator.SetBool(AnimationData.LeftLegUpParameterHash, false);
            animator.SetBool(AnimationData.RightLegUpParameterHash, true);
        }
    }

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
