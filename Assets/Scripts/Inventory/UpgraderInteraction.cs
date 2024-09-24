using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgraderInteraction : MonoBehaviour
{
    [SerializeField]
    private Transform player;

    void OnTriggerEnter(Collider collider) {
        if (collider.CompareTag("Player")) {
            InventoryManager.instance.nearUpgrader = true;
        }
    }

    void OnTriggerExit(Collider collider) {
        if (collider.CompareTag("Player")) {
            InventoryManager.instance.nearUpgrader = false;;
        }
    }
}
