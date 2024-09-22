using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using UnityEngine;

public class MeleeHitThree : MonoBehaviour
{

    private bool targetHit;

    void Start()
    {
        targetHit = false;
    }

   async private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "enemy")
        {
            Debug.Log("enemny got it3rd");
        }
    }
}
