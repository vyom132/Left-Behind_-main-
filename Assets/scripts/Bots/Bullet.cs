using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{   

    public float lifeTime = 5f;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void OnCollisionEnter(Collision other) {
        Debug.Log("Instantiate Particles");
        Destroy(gameObject);

        // Check if it hit the player or other objects and handle accordingly
        if (other.gameObject.CompareTag("Player"))
        {
            // Handle player hit logic here
            Debug.Log("Player hit!");
        }
    }
}
