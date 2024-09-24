using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BotInteraction : MonoBehaviour
{

    public GameObject Interactor;

    bool getrid;

    public void Interact() {
        Debug.Log("interact");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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