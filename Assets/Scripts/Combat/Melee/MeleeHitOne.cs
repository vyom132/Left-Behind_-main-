using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class MeleeHitOne : MonoBehaviour
{ 
    private bool targetHit;
    public GameObject parent;
    public GameObject particle;

    void Start()
    {
        targetHit= false;
    }

    private async void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "enemy")
        {
            Debug.Log("wall got it");
            GameObject spark = Instantiate(particle, parent.transform.position, Quaternion.identity);
            spark.transform.SetParent(parent.gameObject.transform);
            
            await Task.Delay(1000);
            Destroy(spark);
        }
    }
}
