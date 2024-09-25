using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Store : MonoBehaviour
{
    public Transform player;

    void Update() {
        if((player.transform.position - transform.position).magnitude <= 15) {
            InventoryManager.instance.nearStore = true;
        } else
        {
            InventoryManager.instance.nearStore = false;
        }
    }
}
