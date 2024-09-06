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

    public bool Add(Item item, int count) {
        if (!items.Contains(item)) {
            items.Add(item);
            counts.Add(count);
        } else
        {
            counts[items.IndexOf(item)] += count;
        }

        if (onInventoryChangeCallback != null) {
            Debug.Log("Calling onInventoryChangeCallback");
            onInventoryChangeCallback.Invoke();
        }
        return true;
    }

    public void Decrease(Item item) {
        items.Remove(item);
        if (onInventoryChangeCallback != null)
        onInventoryChangeCallback.Invoke();
    }
}
