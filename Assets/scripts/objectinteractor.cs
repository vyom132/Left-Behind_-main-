using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class ObjectInteractor : MonoBehaviour
{
    public GameObject text; 

    async void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            text.SetActive(true);
            Debug.Log("display ui");
        }
    }

    async void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            text.SetActive(false);
            Debug.Log("display ui gone");
        }
    }
}
