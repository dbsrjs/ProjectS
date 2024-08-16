using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class Player : MonoBehaviour
{
    private PlayerMovement3D playerMovement3D;
    [SerializeField] private Camera camera;

    public GameObject prefab;

    public int cnt;
    public Text parkIQText;

    private void Awake()
    {
        playerMovement3D = GetComponent<PlayerMovement3D>();

    }

    void Update()
    {
        float hAxis = Input.GetAxisRaw("Horizontal");
        float vAxis = Input.GetAxisRaw("Vertical");

        playerMovement3D.MoveTo(new Vector3(hAxis, 0, vAxis));

        if (Input.GetKeyDown(KeyCode.Space)) //점프
            playerMovement3D.JumpTo();

        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        camera.RotaTo(mouseX, mouseY);

        if (Input.GetMouseButtonDown(0))
            Instantiate(prefab, transform.position, Quaternion.EulerAngles(new Vector3(0, 0, 90)));
    }

    public void Plus()
    {
        cnt += 10;
        parkIQText.text = "박시우 IQ : -" + cnt;
    }
}