using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private Text parkIQText;

    [Header("Gun")]
    [SerializeField] private Transform bulletPos; //총알 생성 위치
    [SerializeField] private GameObject bullet;   //총알

    [SerializeField]
    private CameraController cameraController;
    private PlayerMovement movement;

    private int cnt;

    Vector3 moveVec;    //이동 좌표

    private void Awake()
    {
        movement = GetComponent<PlayerMovement>(); 
    }

    void Update()
    {
        float hAxis = Input.GetAxisRaw("Horizontal");
        float vAxis = Input.GetAxisRaw("Vertical");
        moveVec = new Vector3(hAxis, 0, vAxis).normalized;      //normalized : 어떤 방향이든 이동 속도를 1로 고정시켜줌

        movement.MoveTo(moveVec);

        if (Input.GetKeyDown(KeyCode.Space))
            movement.JumpTo();

        if (Input.GetMouseButtonDown(0))        //공격
            StartCoroutine(Shot());

        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        cameraController.RotateTo(mouseX, mouseY);
    }

    public void Plus()
    {
        cnt += 10;
        parkIQText.text = "박시우 IQ : -" + cnt;
    }

    private IEnumerator Shot()
    {
        //총알 발사
        GameObject intantBullet = Instantiate(bullet, bulletPos.position, Quaternion.Euler(90, 0, 0));
        yield return null;
    }
}