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
    public bool isTraderSlot = false;
    public Item item;
    public bool isEmpty = true;

    InventoryManager inventory;
    InventoryUI inventoryUI;

    void Start() {
        inventory = InventoryManager.instance;
        inventoryUI = InventoryUI.instance;
    }

    public void ChangeItem(Item newItem, int newCount) {
        isEmpty = false;
        item = newItem;
        icon.sprite = item.icon;
        icon.enabled = true;
        countTMP.text = newCount.ToString();
    }

    public void RemoveItem() {
        if (!isEmpty) {
            item = null;
            icon.enabled = false;
            countTMP.text = "";
            isEmpty = true;
        }
        // else
        // {
        //     Debug.Log("Slot is already empty");
        // }
    }

    public void SelectItem() {
        if (isEmpty) {
            Debug.Log("Slot is empty");
        } else if (isChestSlot)
        {
            inventory.CollectItemFromChest(item);
        } else if (isTraderSlot)
        {
            TradingManager.instance.InitiateTrade(item);
        } else
        {
            if (inventory.nearStore && item.isTradable) {
                TradingManager.instance.UpdateTraderUI();
            }
            
            if (inventory.selected == item) {
                Debug.Log("Deselecting " + item.itemName);
                inventoryUI.Deselect();
            } else
            {
                Debug.Log("Selecting " + item.itemName);
                inventoryUI.Select(item);
            }
        }
    }
}
