using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BotInteract : MonoBehaviour
{
    public GameObject Interactor;
    bool getrid;

    public void Interact()
    {
        Debug.Log("interact");
    }

    void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            Interactor.SetActive(true);
            getrid = false;
        }
    }

    void OnTriggerExit(Collider other) {
        if (other.CompareTag("Player")) {
            Interactor.SetActive(false);
        }
    }
}
