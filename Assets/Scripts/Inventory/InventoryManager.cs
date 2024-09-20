 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager instance; void Awake() { instance = this; }

    public List<Item> chestOne = new List<Item>();
    public List<Item> chestTwo = new List<Item>();
    public List<Item> chestThree = new List<Item>();

    public List<Item> items = new List<Item>();
    public List<int> counts = new List<int>();
    public Item selected;
    public int currency = 0;
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

        InventoryUI.instance.UpdateUI();
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

        InventoryUI.instance.UpdateUI();
    }

    public void UpdateCurrency(int value) {
        if (value <= currency) {
            currency += value;
            Debug.Log("Changed currency by " + value);
        } else
        {
            Debug.Log("Currency too low");
        }
    }

    public void CollectItemFromChest(Item item) {
        GetChestItems()[GetChestItems().IndexOf(item)] = null;
        Increase(item, 1);
        Debug.Log("Moved " + item.itemName + " from chest to inventory");
    }

    public List<Item> GetChestItems() {
        switch (chestID)
        {
            case 1:
                return chestOne;
            case 2:
                return chestTwo;
            case 3:
                return chestThree;
            default:
                Debug.Log("Can't access chest items");
                return null;
        }
    }
}
