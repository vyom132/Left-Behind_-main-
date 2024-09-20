using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeHitTwo : MonoBehaviour
{
    private bool targetHit;

    void Start()
    {
        targetHit = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "enemy")
        {
            Debug.Log("wall got it2nd");
        }
    }
}
