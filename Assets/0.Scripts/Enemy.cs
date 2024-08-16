using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Info")]
    public float speed = 5f;
    public float hp = 100;
    public Transform target;
    bool die = false;

    [Header("Other")]
    private GameObject player;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").gameObject;
        target = player.transform;
    }

    private void Start()
    {
        print("박시우 바보");
    }

    private void Update()
    {
        transform.position = new Vector3(transform.position.x, 1, transform.position.z);

        if(!die)
            Move();
    }

    public void Move()
    {
        if (target != null)
        {
            // 플레이어와의 거리 계산
            float distance = Vector3.Distance(this.transform.position, target.position);
                
            Vector3 direction = (target.position - transform.position).normalized;
            this.transform.position += direction * speed * Time.deltaTime;
        }
    }

    public void Hit(float damage)
    {
        hp -= damage;
        Debug.Log(hp);
        if (hp <= 0)
        {
            Debug.Log("DIE");
            player.GetComponent<Player>().Plus();
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "bullet")
        {
            Hit(10);
            Debug.Log("HIT");
        }
    }
}
