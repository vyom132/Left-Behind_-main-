using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempCam : MonoBehaviour
{

    public float mouseSensitivity = 100f;
    public Transform playerBody;

    float xRotation = 0f;
    bool inv = false;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!inv) {
            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

            xRotation -= mouseY;
            xRotation = Math.Clamp(xRotation, -90f, 90f);

            transform.localRotation = Quaternion.Euler(xRotation,0,0);
            playerBody.Rotate(Vector3.up * mouseX);
        }

        if (Input.GetKeyDown(KeyCode.Q)) {
            if (inv) {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                inv = false;
            } else
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                inv = true;
            }

        }
    }
}