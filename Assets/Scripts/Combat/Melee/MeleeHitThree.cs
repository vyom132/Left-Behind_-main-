using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeHitThree : MonoBehaviour
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
            Debug.Log("enemny got it3rd");
        }
    }
}
