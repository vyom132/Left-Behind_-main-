using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager instance; void Awake() { instance = this; }

    // public static List<Item> inventoryStorage.items = new List<Item>();
    // public static List<int> inventoryStorage.counts = new List<int>();

    public InventoryStorage inventoryStorage;
    public ChestsInLevel chestsInLevel;
    public Item selected = null;
    public bool nearStore = false;
    public bool nearChest = false;
    public int chestID = 0;

    // TEMPORARY, WILL BE REMOVED AND ADDED TO START OF GAME AFTER IMPLEMENTATION
    void Start() {
        Debug.Log("Resetting...");
        inventoryStorage.items.Clear();
        inventoryStorage.counts.Clear();

        for (int i = 0; i < chestsInLevel.wasCollected.Count; i++) {
            chestsInLevel.wasCollected[i] = false;
        }
    }

    public void Increase(Item item, int count) {
        if (inventoryStorage.items.Contains(item)) {
            inventoryStorage.counts[inventoryStorage.items.IndexOf(item)] += count;
        } else
        {
            bool found = false;
            for (int i = 0; i < inventoryStorage.items.Count; i++)
            {
                if (inventoryStorage.counts[i] == 0) {
                    inventoryStorage.items[i] = item;
                    inventoryStorage.counts[i] = count;
                    found = true;
                    break;
                }
            }
            if (!found) {
                inventoryStorage.items.Add(item);
                inventoryStorage.counts.Add(count);
            }
        }
    }

    public void Decrease(Item item, int count) {
        if (!inventoryStorage.items.Contains(item)) {
            Debug.Log("Item " + item.name + " doesn't exist in inventory");
        }

        int index = inventoryStorage.items.IndexOf(item);
        if (count == inventoryStorage.counts[index]) {
            inventoryStorage.counts[index] = 0;
            inventoryStorage.items[index] = null;
            Debug.Log("Removed " + item.name + " from inventory");
            InventoryUI.instance.Deselect();
        } else if (count < inventoryStorage.counts[index])
        {
            inventoryStorage.counts[index] -= count;
            Debug.Log("Reduced count of " + item.name + " by " + count);
        } else
        {
            Debug.Log("Not possible to decrease by more than existing amount");
        }
    }

    public void CollectItemsFromChest() {
        for (int i = 0; i < GetChest().counts.Count; i++) {
            Increase(GetChest().items[i], GetChest().counts[i]);
        }

        Debug.Log("Moved items from chest to inventory");
        chestsInLevel.wasCollected[chestID] = true;
        nearChest = false;
        InventoryUI.instance.UpdateUI(true);
    }

    public Chest GetChest() {
        foreach (var count in chestsInLevel.chests[chestID].counts) {
            Debug.Log(count);
        }
        return chestsInLevel.chests[chestID];
    }

    public void ChangeChestID(int id, bool active) {
        if (chestsInLevel.wasCollected[chestID]) {
            nearChest = false;
        } else
        {
            nearChest = active;
        }

        chestID = id;
    }
}
