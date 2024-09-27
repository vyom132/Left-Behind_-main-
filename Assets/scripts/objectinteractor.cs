using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class ObjectInteractor : MonoBehaviour
{
    [SerializeField]
    private GameObject text;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) {
            text.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Escape)) {
            text.SetActive(true);
        }
    }

    async void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            text.SetActive(true);
        }
    }

    async void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            text.SetActive(false);
        }
    }
}
