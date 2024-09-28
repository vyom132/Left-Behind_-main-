using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dooropening : MonoBehaviour
{
    [SerializeField]
    public Animator anim;
    public List<GameObject> enemies;

    async void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            anim.SetBool("is open", true);
            foreach (var thing in enemies) {
                thing.SetActive(true);
            }
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
