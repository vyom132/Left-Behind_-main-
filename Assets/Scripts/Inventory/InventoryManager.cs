 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager instance; void Awake() { instance = this; }

    public static List<Item> items = new List<Item>();
    public static List<int> counts = new List<int>();

    public List<Chest> chestsInScene;
    public Item selected = null;
    public bool nearStore = false;
    public int chestID = 0; // 0 if not in chest, otherwise ID of chest

    public void Increase(Item item, int count) {
        if (items.Contains(item)) {
            counts[items.IndexOf(item)] += count;
        } else
        {
            bool found = false;
            for (int i = 0; i < items.Count; i++)
            {
                if (counts[i] == 0) {
                    items[i] = item;
                    counts[i] = count;
                    found = true;
                    break;
                }
            }
            if (!found) {
                items.Add(item);
                counts.Add(count);
            }
        }
    }

    public void Decrease(Item item, int count) {
        if (!items.Contains(item)) {
            Debug.Log("Item " + item.name + " doesn't exist in inventory");
        }

        int index = items.IndexOf(item);
        if (count == counts[index]) {
            counts[index] = 0;
            items[index] = null;
            Debug.Log("Removed " + item.name + " from inventory");

            if (items[index] == selected)
            InventoryUI.instance.Deselect();
        } else if (count < counts[index])
        {
            counts[index] -= count;
            Debug.Log("Reduced count of " + item.name + " by " + count);
        } else
        {
            Debug.Log("Not possible to decrease by more than existing amount");
        }
    }

    public void CollectItemFromChest(Item item) {
        int index = chestsInScene[chestID-1].items.IndexOf(item);

        Increase(item, chestsInScene[chestID-1].counts[index]);
        Debug.Log("Moved " + item.itemName + " (" + chestsInScene[chestID-1].counts[index] + ") from chest to inventory");

        chestsInScene[chestID-1].items[index] = null;
        chestsInScene[chestID-1].counts[index] = 0;
        InventoryUI.instance.UpdateUI();
    }
}
