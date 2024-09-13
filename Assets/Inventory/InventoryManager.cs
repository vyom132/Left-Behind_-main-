using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager instance; void Awake() { instance = this; }

    public delegate void OnInventoryChange();
    public OnInventoryChange onInventoryChangeCallback;

    public List<Item> items = new List<Item>();
    public List<int> counts = new List<int>();
    public int currency = 0;

    public bool Increase(Item item, int count) {
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

        if (onInventoryChangeCallback != null) {
            Debug.Log("Calling onInventoryChangeCallback");
            onInventoryChangeCallback.Invoke();
        }
        return true;
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

        if (onInventoryChangeCallback != null) {
            Debug.Log("Calling onInventoryChangeCallback");
            onInventoryChangeCallback.Invoke();
        }
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
}
