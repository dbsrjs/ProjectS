using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 5.0f; //�̵� �ӵ�
    [SerializeField]
    private float jumpForce = 2.0f; //�ٴ� ��
    private float gravity = -9f;    //�߷�
    private Vector3 moveDirection;  //�̵� ����

    [SerializeField]
    private Transform cameraTransform;  
    private CharacterController characterController;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        if(characterController.isGrounded == false) //ĳ���Ͱ� �ٴڿ� ������� ���� �� ������ ���������� �߷� ����
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
