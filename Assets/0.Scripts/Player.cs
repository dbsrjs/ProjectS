using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private Text parkIQText;

    [Header("Gun")]
    [SerializeField] private Transform bulletPos; //�Ѿ� ���� ��ġ
    [SerializeField] private GameObject bullet;   //�Ѿ�

    [SerializeField]
    private CameraController cameraController;
    private PlayerMovement movement;

    private int cnt;

    Vector3 moveVec;    //�̵� ��ǥ

    private void Awake()
    {
        movement = GetComponent<PlayerMovement>(); 
    }

    void Update()
    {
        float hAxis = Input.GetAxisRaw("Horizontal");
        float vAxis = Input.GetAxisRaw("Vertical");
        moveVec = new Vector3(hAxis, 0, vAxis).normalized;      //normalized : � �����̵� �̵� �ӵ��� 1�� ����������

        movement.MoveTo(moveVec);

        if (Input.GetKeyDown(KeyCode.Space))
            movement.JumpTo();

        if (Input.GetMouseButtonDown(0))        //����
            StartCoroutine(Shot());

        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        cameraController.RotateTo(mouseX, mouseY);
    }

    public void Plus()
    {
        cnt += 10;
        parkIQText.text = "�ڽÿ� IQ : -" + cnt;
    }

    private IEnumerator Shot()
    {
        //�Ѿ� �߻�
        GameObject intantBullet = Instantiate(bullet, bulletPos.position, Quaternion.Euler(90, 0, 0));
        yield return null;
    }
}