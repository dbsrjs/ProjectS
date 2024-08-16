using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement3D : MonoBehaviour
{
    [Header("Info")]
    private float speed = 8.0f;     //이동 속도
    private float jumpForce = 2.5f; //점프 힘
    private float gravity = -10f;   //중력 값(반드시 음수여야함)

    [Header("State")]
    bool isRun; //달리고 있을 때

    private Vector3 moveDirection;  //이동 방향

    [SerializeField] private Transform cameraTransform;
    private CharacterController characterController;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {

        //발 위치의 충돌을 체크해 충돌 중이라면 true 아니면 false
        if (characterController.isGrounded == false)
        {
            //중력 구현
            moveDirection.y += gravity * Time.deltaTime;
        }
        //moveDirection의 방향으로 isRun에 의거 speed의 속도로 이동
        characterController.Move(moveDirection * speed * Time.deltaTime);
    }

    /// <summary>
    /// 방향 정보를 매개변수로 받아오면 방향 정보를 moveDirection에 저장
    /// </summary>
    public void MoveTo(Vector3 direction)
    {
        Vector3 movedis = cameraTransform.rotation * direction;
        moveDirection = new Vector3(movedis.x, moveDirection.y, movedis.z);
    }

    /// <summary>
    /// 점프 로직
    /// </summary>
    public void JumpTo()
    {
        //발 위치의 충돌을 체크해 충돌 중이라면 true 아니면 false
        if (characterController.isGrounded == true)
        {
            moveDirection.y = jumpForce;
        }
    }
}