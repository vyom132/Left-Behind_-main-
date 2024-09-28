using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class groundsmash : MonoBehaviour
{
    public float damageRadius;
    public float damage;
    bool readyTosmash;
    // Start is called before the first frame update
    void GroundSmash()
    {
        readyTosmash= false;
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, damageRadius); // damage radius is the radius of the area the damage should take place, float var

        // Loop through all hit colliders
        foreach (Collider hitCollider in hitColliders)
        {
            // Check if the collider has the "Enemy" tag
            if (hitCollider.CompareTag("Enemy"))
            {
                hitCollider.gameObject.GetComponent<EnemyHealthManager>().TakeDamage(damage);
                // Basically damage should be done here
            }
        }
    }

    private void Start()
    {
            readyTosmash= true;
    }
    private async void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && readyTosmash) {

            
            
            GroundSmash();
            await Task.Delay(5000);
            readyTosmash = true;
        }

    }
    //Check magicball and ballmagic scripts for refernce
    // ps.magicball should be on player, ballmagic on the Energy ball prefab that will be instantiated
}
