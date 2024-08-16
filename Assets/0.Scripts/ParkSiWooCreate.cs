using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParkSiWooCreate : MonoBehaviour
{
    public GameObject target;
    public GameObject siWooPrefab;

    private void Awake()
    {
        target = GameObject.Find("Player").gameObject;
    }

    private void Start()
    {
        StartCoroutine(Create());
    }

    private IEnumerator Create()
    {
        float targetX = target.transform.position.x;
        float targetZ = target.transform.position.z;

        float ranX = Random.Range(targetX - 50f, targetX + 50f);
        float ranZ = Random.Range(targetZ - 50f, targetZ + 50f);

        Vector3 pos = new Vector3(ranX, 1, ranZ);

        Instantiate(siWooPrefab, pos, Quaternion.identity);

        yield return new WaitForSeconds(5);

        StartCoroutine(Create());
    }
}
