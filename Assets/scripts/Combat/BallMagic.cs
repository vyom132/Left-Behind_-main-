using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class BallMagic : MonoBehaviour
{
    public float lifeTime = 5f;

    public float damageRadius = 5f;
    public float damage;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, lifeTime);
        SplashItUp();
    }


    // Update is called once per frame
    void Update()
    {

    }


    void OnTriggerEnter(Collider other)
    { 
        SplashItUp();
        Destroy(gameObject);
    }

    void SplashItUp()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, damageRadius);

        // Loop through all hit colliders
        foreach (Collider hitCollider in hitColliders)
        {
            // Check if the collider has the "Enemy" tag
            if (hitCollider.CompareTag("Enemy"))
            {
                hitCollider.gameObject.GetComponent<EnemyHealthManager>().TakeDamage(damage);
                
            }
        }
    }

}
