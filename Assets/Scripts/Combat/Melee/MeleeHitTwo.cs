using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using UnityEngine;

public class MeleeHitTwo : MonoBehaviour
{
    private bool targetHit;
    public GameObject parent;
    public GameObject particle;

    void Start()
    {
        targetHit = false;
    }

    async private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "enemy")
        {
            Debug.Log("wall got it2nd");
            GameObject spark = Instantiate(particle, parent.transform.position, Quaternion.identity);

            //await Task.Delay(2000);
            Destroy(spark);
        }
    }
}
