using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField]
    float mouseSens = 100f;

    [SerializeField]
    float speed = 12f;

    [SerializeField]
    float gravity = -9.8f;

    CharacterController controller;
    Transform player;
    GameObject camera;
    Transform cameraTransform;
    GameObject flashlight;
    Light lightsource;

    Vector3 moveVel;
    Vector3 turnVel;
    float x;
    float z;
    float mouseX;
    float mouseY;
    float xRotation = 0f;
    bool active = true;
    bool isOn = true;

    void Awake()
    {
        camera = GameObject.Find("Camera");
        cameraTransform = camera.GetComponent<Transform>();
        flashlight = GameObject.Find("Flashlight");
        lightsource = flashlight.GetComponent<Light>();
        controller = GetComponent<CharacterController>();
        player = GetComponent<Transform>();
    }

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void FixedUpdate()
    {
        if (active)
        {
            // movement
            x = Input.GetAxis("Horizontal");
            z = Input.GetAxis("Vertical");
            Vector3 move = transform.right * x + transform.forward * z;
            controller.Move(move * speed * Time.deltaTime);
            moveVel.y += gravity * Time.deltaTime;
            controller.Move(moveVel * Time.deltaTime);
            transform.Rotate(turnVel * Time.deltaTime);

            // mouse look
            mouseX = Input.GetAxis("Mouse X") * mouseSens * Time.deltaTime;
            mouseY = Input.GetAxis("Mouse Y") * mouseSens * Time.deltaTime;
            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);
            cameraTransform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
            player.Rotate(Vector3.up * mouseX);
        }
    }

    void Update()
    {
        //flashlight
        if (lightsource.intensity > 0)
        {
            isOn = true;
        }
        if (lightsource.intensity <= 0)
        {
            isOn = false;
        }
        if (Input.GetKeyDown(KeyCode.F) & isOn == true)
        {
            lightsource.intensity = 0f;
        }
        if (Input.GetKeyDown(KeyCode.F) & isOn == false)
        {
            lightsource.intensity = 1.5f;
        }
    }

    public void ChangeState(bool value)
    {
        active = value;
    }

    private void ApplyRotation() { }
}
