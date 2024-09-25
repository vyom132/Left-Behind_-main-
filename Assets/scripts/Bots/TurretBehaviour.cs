using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretBehaviour : MonoBehaviour
{

    public GameObject bulletFab;
    public Transform player;

    float detectionRange = 20f;

    public Transform firePoint;
    
    public float fireRate = 2f;      // How often the turret fires
    private float nextFireTime = 0f; // When the turret can fire next
    
    public float bulletSpeed = 10f;

    float rotationSpeed = 180f;

    float interactRange = 20f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Collider[] colliderArray = Physics.OverlapSphere(transform.position, interactRange);

        // foreach(Collider collider in colliderArray) {
        //     if (collider.TryGetComponent(out Interactor interact)) {
        //         StartShooting();
        //     }
        // }

        if (IsPlayerInRange()) {
                    // Check if the turret can fire (based on fireRate)
            if (Time.time >= nextFireTime)
            {
                StartShooting();
                playernichudaraerripooka();
                nextFireTime = Time.time + 1f / fireRate;  // Set the next fire time
            }
    
        }

    }

    private bool IsPlayerInRange()
    {
        // Get all colliders within the detection range
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, detectionRange);

        foreach (Collider collider in hitColliders)
        {
            if (collider.CompareTag("Player")) // Ensure the collider is the player
            {
                return true; // Player is within range
            }
        }

        return false; // Player is not within range
    }

    void StartShooting() {
                    // Instantiate the bullet at the fire point (turret) position
        GameObject bullet = Instantiate(bulletFab, firePoint.position, Quaternion.identity);

        // Calculate the direction from the turret (fire point) to the player
        Vector3 direction = player.position - firePoint.position;

        Debug.DrawLine(firePoint.position, player.position, Color.red, 2f);


        // Set the bullet's velocity to move towards the player
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        // rb.velocity = direction * bulletSpeed;

        if (rb != null)
        {
            rb.velocity = direction * bulletSpeed;
            Debug.Log("vel");
        }
    
    }

    void playernichudaraerripooka() {
         // Calculate the direction to the player
         // Calculate the direction to the player
    Vector3 direction = (player.position - transform.position).normalized;

    if (direction != Vector3.zero) // Prevent LookRotation with zero vector
    {
        // Calculate the target rotation
        Quaternion targetRotation = Quaternion.LookRotation(direction);

        // Keep the current X and Z rotations
        Quaternion currentRotation = transform.rotation;
        targetRotation = Quaternion.Euler(0, targetRotation.eulerAngles.y, 0); // Set X and Z to 0

        // Log the target rotation for debugging
        Debug.Log("Target Rotation: " + targetRotation.eulerAngles);

        // Smoothly rotate towards the player
        transform.rotation = Quaternion.Slerp(currentRotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
    }
}
