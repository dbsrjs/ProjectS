using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void Start()
    {
        transform.Rotate(0, 0, 180);
    }

    private void Update()
    {
        float time = 0;

        time += Time.deltaTime;

        if(time >= 3f)
            Destroy(gameObject);

        transform.position += new Vector3(0.001f, 0, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "park")
            Destroy(gameObject);
    }
}
