using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    // Temporary script for testing inventory, to be changed during implementation

    public Item item;
    public Transform player;

    void Update() {
        if(Input.GetMouseButtonDown(1) && (player.transform.position - transform.position).magnitude <= 15) {
            Pickup();
            Destroy(gameObject);
        }
    }

    public void Pickup() {
        Debug.Log("Picking up item " + item.itemName);
        InventoryManager.instance.Increase(item, 1);
        InventoryUI.instance.UpdateUI();
    }
}
