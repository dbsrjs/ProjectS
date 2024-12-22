using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

public class PakSiWoo : MonoBehaviour
{
    [Header("Info")]
    public float speed = 5f;
    public float hp = 100;
    bool die = false;

    [Header("Other")]
    private GameObject player;

    [SerializeField] private GameObject textGameObj;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").gameObject;
    }

    private void Update()
    {
        transform.position = new Vector3(transform.position.x, 1, transform.position.z);

        //textGameObj.transform.LookAt(target);
        textGameObj.transform.rotation = player.transform.rotation;
        //transform.rotation = Cam.transform.rotation;

        if (!die)
            Move();
    }

    public void Move()
    {
        if (player != null)
        {
            // 플레이어와의 거리 계산
            float distance = Vector3.Distance(this.transform.position, player.transform.position);
                
            Vector3 direction = (player.transform.position - transform.position).normalized;
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
}
