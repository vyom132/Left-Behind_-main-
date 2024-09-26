using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpening : MonoBehaviour
{
    [SerializeField]
    private Animator anim;

    async void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            anim.SetBool("is open", true);
        }
    }
    async void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            anim.SetBool("is open", false);
        }
    }
}
