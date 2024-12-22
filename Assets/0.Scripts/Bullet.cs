using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public LayerMask collisionMask; // �Ѿ��� �浹�� �� �ִ� ���̾� ����ũ

    float speed = 10;
    float damage = 20;

    float what_do_I_call_this_variable = 0.1f;  //���� �̵��� �Ѿ��� �̵��� ���� �����ӿ��� �Ͼ�� �浹�� �� �Ǵ� ���� ���� ���ִ� ��.

    private void Start()
    {
        Destroy(gameObject, 3f);

        // �Ѿ��� ������ ��ġ���� 0.1f �ݰ� ���� �浹�� �� �ִ� ��ü�� �ִ��� Ȯ��
        Collider[] initialCollisions = Physics.OverlapSphere(transform.position, 0.1f, collisionMask);

        // ���� ���� ������ �̹� �浹 ��ü�� ���� ������ OnHitObject ȣ��
        if (initialCollisions.Length > 0)   //�Ѿ��� ���� ���� �� � �浹ü ������Ʈ�� �̹� ��ģ ������ ��
            OnHitObject(initialCollisions[0], transform.position);
    }

    void Update()
    {
        float moveDistance = speed * Time.deltaTime;          // �̵��� �Ÿ��� ��� (�ӵ� * ������ �ð�)
        CheckCollisions(moveDistance);                        // �̵� ��ο��� �浹 üũ
        transform.Translate(Vector3.forward * moveDistance);  // �Ѿ��� ���������� �̵�
    }

    /// <summary>
    /// �̵� �Ÿ� ���� �浹�� ��ü�� �ִ��� üũ�ϴ� �Լ�
    /// </summary>
    void CheckCollisions(float moveDistance)
    {
        // �Ѿ��� ���� ��ġ���� �������� Raycast�� ���� �浹�� ����
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        // Ray�� �浹ü�� �����ϸ� OnHitObject ȣ��
        if (Physics.Raycast(ray, out hit, moveDistance + what_do_I_call_this_variable, collisionMask, QueryTriggerInteraction.Collide))
        {
            OnHitObject(hit.collider, hit.point);
        }
    }

    /// <summary>
    /// �Ѿ��� �浹�� ��ü�� ���� ó��
    /// </summary>
    void OnHitObject(Collider c, Vector3 hitPoint)
    {
        //�浹 ��ü�� ���� ó��(HP ���� || ���)
        Destroy(gameObject);   //�Ѿ� ����
        c.GetComponent<PakSiWoo>().Hit(damage);
    }
}
