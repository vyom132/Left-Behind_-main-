using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Store : MonoBehaviour
{
    public Transform player;
    public Canvas inventory;

    void Update() {
        if(Input.GetMouseButtonDown(0) && (player.transform.position - transform.position).magnitude <= 15) {
            Debug.Log("Enabling store");
            inventory.enabled = true;
            InventoryManager.instance.inStore = true;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}
