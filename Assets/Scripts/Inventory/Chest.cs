using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    public int chestID;
    public Transform player;

    void Update() {
        if((player.transform.position - transform.position).magnitude <= 15) {
            InventoryManager.instance.chestID = chestID;
        } else
        {
            InventoryManager.instance.chestID = 0;
        }
    }
}
