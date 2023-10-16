using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterController : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 5f;
    [SerializeField]
    private Transform characterBody;
    [SerializeField]
    private Transform cameraArm;

    public LayerMask groundLayerMask;
    private Rigidbody _rigidbody;
    private Vector2 direction;

    public float testRay = 0.6f;
    private bool IsJump;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        //animator = characterBody.GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void Move(Vector2 inputDirection)
    {

        // 이동 방향키 입력 값 가져오기
        Vector2 moveInput = inputDirection;
        // 이동 방향키 입력 판정 : 이동 방향 벡터가 0보다 크면 입력이 발생하고 있는 중
        bool isMove = moveInput.magnitude != 0;
        // 입력이 발생하는 중이라면 이동 애니메이션 재생
        //animator.SetBool("isMove", isMove);
        if (isMove)
        {
            // 카메라가 바라보는 방향
            Vector3 lookForward = new Vector3(cameraArm.forward.x, 0f, cameraArm.forward.z).normalized;
            // 카메라의 오른쪽 방향
            Vector3 lookRight = new Vector3(cameraArm.right.x, 0f, cameraArm.right.z).normalized;
            // 이동 방향
            Vector3 moveDir = lookForward * moveInput.y + lookRight * moveInput.x;
            // 이동할 때 이동 방향 바라보기
            characterBody.forward = moveDir;
            // 이동
            transform.position += moveDir * Time.deltaTime * speed;
        }
    }
    private void MoveKey(Vector2 direction)
    {
        Vector2 moveInput = direction;
        // 이동 방향키 입력 판정 : 이동 방향 벡터가 0보다 크면 입력이 발생하고 있는 중
        bool isMove = moveInput.magnitude != 0;
        // 입력이 발생하는 중이라면 이동 애니메이션 재생
        //animator.SetBool("isMove", isMove);
        if (isMove)
        {
            // 카메라가 바라보는 방향
            Vector3 lookForward = new Vector3(cameraArm.forward.x, 0f, cameraArm.forward.z).normalized;
            // 카메라의 오른쪽 방향
            Vector3 lookRight = new Vector3(cameraArm.right.x, 0f, cameraArm.right.z).normalized;
            // 이동 방향
            Vector3 moveDir = lookForward * moveInput.y + lookRight * moveInput.x;
            // 이동할 때 이동 방향 바라보기
            characterBody.forward = moveDir;
            // 이동
            transform.position +=  moveDir * Time.deltaTime * speed;
        }
    }
    private void OnMove(InputValue value)
    {
        direction = value.Get<Vector2>().normalized;
    }

        private void FixedUpdate()
    {
        MoveKey(direction);
    }


    private bool IsGrounded()
    {
        Ray[] rays = new Ray[4]
        {
            new Ray(transform.position + (transform.forward * 0.2f) + (Vector3.up * 0.01f) , Vector3.down),
            new Ray(transform.position + (-transform.forward * 0.2f)+ (Vector3.up * 0.01f), Vector3.down),
            new Ray(transform.position + (transform.right * 0.2f) + (Vector3.up * 0.01f), Vector3.down),
            new Ray(transform.position + (-transform.right * 0.2f) + (Vector3.up * 0.01f), Vector3.down),
        };

        for (int i = 0; i < rays.Length; i++)
        {
            if (Physics.Raycast(rays[i], testRay, groundLayerMask))
            {
                return true;
            }
        }
        return false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position + (transform.forward) + (Vector3.up * 0.01f), Vector3.down);
        Gizmos.DrawRay(transform.position + (-transform.forward) + (Vector3.up * 0.01f), Vector3.down);
        Gizmos.DrawRay(transform.position + (transform.right)+(Vector3.up * 0.01f), Vector3.down);
        Gizmos.DrawRay(transform.position + (-transform.right) + (Vector3.up * 0.01f), Vector3.down);
    }



    public void OnJump(InputValue value)//키보드 스페이스바 점프
    {
        Jump();
    }
    public void Jump() 
    {
        if (IsGrounded()) 
        {
            _rigidbody.AddForce(Vector2.up * jumpForce, ForceMode.Impulse);
        }
    }
}
