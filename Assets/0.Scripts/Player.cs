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

    private int cnt;

    Vector3 moveVec;    //이동 좌표

    void Update()
    {
        float hAxis = Input.GetAxisRaw("Horizontal");
        float vAxis = Input.GetAxisRaw("Vertical");
        moveVec = new Vector3(hAxis, 0, vAxis).normalized;      //normalized : 어떤 방향이든 이동 속도를 1로 고정시켜줌
        transform.position += moveVec * 10f * Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space)) //점프

        if (Input.GetMouseButtonDown(0))//공격
            StartCoroutine(Shot());

        Turn();

    }

    public void Plus()
    {
        cnt += 10;
        parkIQText.text = "박시우 IQ : -" + cnt;
    }

    void Turn()
    {
        //#키보드를 이용한 회전
        transform.LookAt(transform.position + moveVec); //플레이어에 이동 방향에 따라 Rotation도 같이 움직임

        //메인 카메라에서 마우스 커서 위치를 기준으로 레이(ray)를 생성
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit rayHit;

        // 레이를 쏴서 길이 8 유닛 이내의 오브젝트와 충돌 여부를 확인
        if (Physics.Raycast(ray, out rayHit, 100)) 
        {
            Vector3 nextVec = rayHit.point - transform.position;
            nextVec.y = 0;
            transform.LookAt(transform.position + nextVec);
        }

    }

    private IEnumerator Shot()
    {
        //총알 발사
        GameObject intantBullet = Instantiate(bullet, bulletPos.position, Quaternion.Euler(90, 0, 0));
        Rigidbody bulletRigid = intantBullet.GetComponent<Rigidbody>();
        bulletRigid.velocity = bulletPos.forward * 50;
        yield return null;
    }
}