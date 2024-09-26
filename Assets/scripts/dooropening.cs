using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dooropening : MonoBehaviour
{
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
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
