using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventoryUI : MonoBehaviour
{
    public static InventoryUI instance; void Awake() { instance = this; }

    InventoryManager inventory;
    InventorySlot[] inventorySlots;
    InventorySlot[] chestSlots;
    List<Item> chestItems;
    List<int> chestCounts;

    public TMP_Text titleTMP;
    public TMP_Text descriptionTMP;

    public GameObject slotsPanel;
    public GameObject chestPanel;
    public GameObject traderPanel;

    void Start()
    {
        GetComponent<Canvas>().enabled = false;
        inventory = InventoryManager.instance;
        inventorySlots = slotsPanel.GetComponentsInChildren<InventorySlot>();
        chestSlots = chestPanel.GetComponentsInChildren<InventorySlot>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) {
            ToggleInventory(true, (inventory.chestID != 0));
        }

        if (Input.GetKeyDown(KeyCode.Escape)) {
            ToggleInventory(false);
        }
    }

    public void ToggleInventory(bool turnOn, bool chest = false) {
        if (turnOn) {
            UpdateUI();

            GetComponent<Canvas>().enabled = true;
            chestPanel.SetActive(chest);

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            inventory.active = true;
            inventory.selected = null;

            TradingManager.instance.UpdateTraderUI();
        } else
        {
            GetComponent<Canvas>().enabled = false;
            chestPanel.SetActive(false);

            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            inventory.active = true;
            inventory.selected = null;
            Deselect();
        }
    }

    public void UpdateUI() {
        Debug.Log("Updating inventory UI");

        for (int i = 0; i < inventory.items.Count; i++)
        {
            if (inventory.counts[i] == 0) {
                inventorySlots[i].RemoveItem();
            } else
            {
                inventorySlots[i].ChangeItem(inventory.items[i], inventory.counts[i]);
            }
        }

        if (inventory.chestID != 0) {
            chestItems = inventory.chests[inventory.chestID-1].items;
            chestCounts = inventory.chests[inventory.chestID-1].counts;

            for (int i = 0; i < chestItems.Count; i++)
            {
                if (chestItems[i] == null) {
                    chestSlots[i].RemoveItem();
                } else
                {
                    chestSlots[i].ChangeItem(chestItems[i], chestCounts[i]);
                }
            }
        }
    }

    public void Select(Item item) {
        inventory.selected = item;
        ChangeDescription(item);

        if (inventory.nearStore)
        TradingManager.instance.UpdateTraderUI();
    }

    public void Deselect() {
        inventory.selected = null;
        ChangeDescription(null);

        if (inventory.nearStore)
        TradingManager.instance.UpdateTraderUI();
    }

    public void ChangeDescription(Item item) {
        if (item == null) {
            titleTMP.text = "";
            titleTMP.enabled = false;
            descriptionTMP.text = "";
            descriptionTMP.enabled = false;
        } else
        {
            titleTMP.text = item.itemName;
            titleTMP.enabled = true;
            descriptionTMP.text = item.description;
            descriptionTMP.enabled = true;
        }
    }
}
