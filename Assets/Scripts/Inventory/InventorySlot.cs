using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventorySlot : MonoBehaviour
{
    public TMP_Text countTMP;
    public Image icon;
    public bool isChestSlot = false;

    bool isEmpty = true;
    public Item item;

    public void ChangeItem(Item newItem, int newCount) {
        if (item == null) {
        isEmpty = false;
        item = newItem;
        icon.sprite = item.icon;
        icon.enabled = true;
        }

        countTMP.text = newCount.ToString();
    }

    public void RemoveItem() {
        if (!isEmpty) {
            item = null;
            icon.enabled = false;
            countTMP.text = "";
            isEmpty = true;
        } else
        {
            Debug.Log("Slot is already empty");
        }
    }

    public void SelectItem() {
        if (isEmpty) {
            Debug.Log("Slot is empty");
        } else if (InventoryManager.instance.chestID != 0)
        {
            InventoryManager.instance.CollectItemFromChest(item);
        } else
        {
            if (InventoryManager.instance.selected == item) {
                Debug.Log("Deselecting " + item.itemName);
                InventoryUI.instance.Deselect();
            } else
            {
                Debug.Log("Selecting " + item.itemName);
                InventoryUI.instance.Select(item);
            }
        }
    }
}
