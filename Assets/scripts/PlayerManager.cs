using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static GameObject playerObject;

    [SerializeField]
    float mouseSens = 100f;
    [SerializeField]
    float speed = 12f;
    [SerializeField]
    float fastspeed = 20f;
    [SerializeField]
    float gravity = -9.8f;
    [SerializeField]
    float jumpforce = 10f;

    [SerializeField]
    private Transform cameraTransform;
    // [SerializeField]
    // private Light lightsource;
    private CharacterController controller;
    private Rigidbody rb;
    private Transform player;

    private bool onground;
    private Vector3 moveVel;
    private Vector3 turnVel;
    private float x;
    private float z;
    private float mouseX;
    private float mouseY;
    private float xRotation = 0f;
    private bool isOn = true;

    void Awake()
    {
        playerObject = gameObject;

        controller = GetComponent<CharacterController>();
        rb = GetComponent<Rigidbody>();
        player = GetComponent<Transform>();
    }

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void FixedUpdate()
    {
        if (!InventoryUI.instance.isActive)
        {
            // movement
            x = Input.GetAxis("Horizontal");
            z = Input.GetAxis("Vertical");
            Vector3 move = transform.right * x + transform.forward * z;
            controller.Move(move * speed * Time.deltaTime);
            if (Input.GetKey(KeyCode.LeftShift)) {

                controller.Move(move * fastspeed * Time.deltaTime);
            }
            
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
        // if (lightsource.intensity > 0)
        // {
        //     isOn = true;
        // }
        // if (lightsource.intensity <= 0)
        // {
        //     isOn = false;
        // }
        // if (Input.GetKeyDown(KeyCode.F) & isOn == true)
        // {
        //     lightsource.intensity = 0f;
        // }
        // if (Input.GetKeyDown(KeyCode.F) & isOn == false)
        // {
        //     lightsource.intensity = 1.5f;
        // }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            onground = true;
        }
    }
}
