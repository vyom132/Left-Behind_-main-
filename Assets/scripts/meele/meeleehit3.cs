using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meeleehit3 : MonoBehaviour
{

    private bool targetHit;
    // Start is called before the first frame update
    void Start()
    {

        targetHit = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "wall")
        {


            Debug.Log("wall got it3rd");
        }


    }

}
