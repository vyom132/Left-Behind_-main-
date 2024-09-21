using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager instance; void Awake() { instance = this; }

    public List<Item> chestOneItems = new List<Item>();
    public List<Item> chestTwoItems = new List<Item>();
    public List<Item> chestThreeItems = new List<Item>();

    public List<int> chestOneCounts = new List<int>();
    public List<int> chestTwoCounts = new List<int>();
    public List<int> chestThreeCounts = new List<int>();

    public List<Item> items = new List<Item>();
    public List<int> counts = new List<int>();

    public Item selected;
    public bool nearStore = false;
    public int chestID = 0; // 0 if not in chest, otherwise ID of chest
    public bool active = false;

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
        int index = GetChestItems().IndexOf(item);

        Increase(item, GetChestCounts()[index]);
        Debug.Log("Moved " + item.itemName + " (" + GetChestCounts()[index] + ") from chest to inventory");

        GetChestItems()[index] = null;
        GetChestCounts()[index] = 0;
        InventoryUI.instance.UpdateUI();
    }

    public List<Item> GetChestItems() {
        switch (chestID)
        {
            case 1:
                return chestOneItems;
            case 2:
                return chestTwoItems;
            case 3:
                return chestThreeItems;
            default:
                Debug.Log("Can't access chest items");
                return null;
        }
    }

    public List<int> GetChestCounts() {
        switch (chestID)
        {
            case 1:
                return chestOneCounts;
            case 2:
                return chestTwoCounts;
            case 3:
                return chestThreeCounts;
            default:
                Debug.Log("Can't access chest counts");
                return null;
        }
    }
}
