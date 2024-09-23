using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestInteraction : MonoBehaviour
{
    [SerializeField]
    private int chestID; // Starts from 1
    [SerializeField]
    private Transform player;

    void OnTriggerEnter(Collider collider) {
        if (collider.CompareTag("Player")) {
            InventoryManager.instance.ChangeChestID(chestID, true);
        }
    }

    void OnTriggerExit(Collider collider) {
        if (collider.CompareTag("Player")) {
            InventoryManager.instance.ChangeChestID(chestID, false);
        }
    }
}
