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

    private int cnt;

    Vector3 moveVec;    //�̵� ��ǥ

    void Update()
    {
        float hAxis = Input.GetAxisRaw("Horizontal");
        float vAxis = Input.GetAxisRaw("Vertical");
        moveVec = new Vector3(hAxis, 0, vAxis).normalized;      //normalized : � �����̵� �̵� �ӵ��� 1�� ����������
        transform.position += moveVec * 10f * Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space)) //����

        if (Input.GetMouseButtonDown(0))//����
            StartCoroutine(Shot());

        Turn();

    }

    public void Plus()
    {
        cnt += 10;
        parkIQText.text = "�ڽÿ� IQ : -" + cnt;
    }

    void Turn()
    {
        //#Ű���带 �̿��� ȸ��
        transform.LookAt(transform.position + moveVec); //�÷��̾ �̵� ���⿡ ���� Rotation�� ���� ������

        //���� ī�޶󿡼� ���콺 Ŀ�� ��ġ�� �������� ����(ray)�� ����
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit rayHit;

        // ���̸� ���� ���� 8 ���� �̳��� ������Ʈ�� �浹 ���θ� Ȯ��
        if (Physics.Raycast(ray, out rayHit, 100)) 
        {
            Vector3 nextVec = rayHit.point - transform.position;
            nextVec.y = 0;
            transform.LookAt(transform.position + nextVec);
        }

    }

    private IEnumerator Shot()
    {
        //�Ѿ� �߻�
        GameObject intantBullet = Instantiate(bullet, bulletPos.position, Quaternion.Euler(90, 0, 0));
        Rigidbody bulletRigid = intantBullet.GetComponent<Rigidbody>();
        bulletRigid.velocity = bulletPos.forward * 50;
        yield return null;
    }
}