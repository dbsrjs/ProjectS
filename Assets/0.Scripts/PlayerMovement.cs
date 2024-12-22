using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 5.0f; //이동 속도
    [SerializeField]
    private float jumpForce = 2.0f; //뛰는 힘
    private float gravity = -9f;    //중력
    private Vector3 moveDirection;  //이동 방향

    [SerializeField]
    private Transform cameraTransform;  
    private CharacterController characterController;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        if(characterController.isGrounded == false) //캐릭터가 바닥에 닿아있지 않을 때 땅으로 떨어지도록 중력 구현
            moveDirection.y += gravity * Time.deltaTime;

        characterController.Move(moveDirection * moveSpeed * Time.deltaTime);
    }

    public void MoveTo(Vector3 direction)
    {
        //moveDirection = new Vector3(direction.x, moveDirection.y, direction.z);
        Vector3 movedis = cameraTransform.rotation * direction;
        moveDirection = new Vector3(movedis.x, moveDirection.y, movedis.z);
    }

    public void JumpTo()
    {
        if (characterController.isGrounded == true)
            moveDirection.y = jumpForce;
    }
}
