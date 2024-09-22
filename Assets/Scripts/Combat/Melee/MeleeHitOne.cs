using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class MeleeHitOne : MonoBehaviour
{ 
    private bool targetHit;
    

    void Start()
    {
        targetHit= false;
    }

    private async void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "enemy")
        {
            Debug.Log("wall got it");
        }
    }
}
