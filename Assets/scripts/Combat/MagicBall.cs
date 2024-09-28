using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class MagicBall : MonoBehaviour
{
    // public Transform Enemy;


    public Transform shootPoint;

    public Transform Cam;

    public float fireRate = 5f; // Fire rate, in seconds
    private float timeSinceLastShot = 0f;


    public float throwCooldown;

    public float ballSpeed;

    bool readyToThrow;


    public GameObject magicBall;


    // Start is called before the first frame update
    void Start()
    {
        readyToThrow = true;
    }


    // Update is called once per frame
    async void Update()
    {
        // Update the timer based on time passed

        // Check if the player presses the shoot button (P key) and can shoot
        if (Input.GetMouseButtonDown(1) && readyToThrow)
        {
            ShootTheBall();
            // Reset the timer after shooting
            await Task.Delay(5000);
            readyToThrow = true;
        }

        
    }


    void ShootTheBall()
    {

        readyToThrow = false;
        GameObject bullet = Instantiate(magicBall, shootPoint.position, Cam.rotation);
        Debug.Log("Is shooting");

        Vector3 direction = Cam.transform.forward;

        // RaycastHit hit;

        // if (Physics.Raycast(Cam.position, Cam.forward, out hit, 500f)) {
        //     direction = (hit.point - shootPoint.position).normalized;
        // }

        // Set the bullet's velocity to move towards the player
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        // rb.velocity = direction * bulletSpeed;

        if (rb != null)
        {
            rb.velocity = Cam.transform.forward * ballSpeed;
        }


    }
}
