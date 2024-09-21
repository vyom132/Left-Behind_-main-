using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    public int chestID;
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
