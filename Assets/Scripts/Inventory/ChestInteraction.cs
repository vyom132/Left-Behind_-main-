using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestInteraction : MonoBehaviour
{
    public int chestID; // Starts from 1
    public Transform player;

    void OnTriggerEnter(Collider collider) {
        if (collider.CompareTag("Player")) {
            InventoryManager.instance.chestID = chestID;
        }
    }

    void OnTriggerExit(Collider collider) {
        if (collider.CompareTag("Player")) {
            InventoryManager.instance.chestID = 0;
        }
    }
}
