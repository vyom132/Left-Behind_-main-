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

            Trader.instance.UpdateTraderUI();
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
        Debug.Log("Updating UI");

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
            chestItems = inventory.GetChestItems();
            chestCounts = inventory.GetChestCounts();

            for (int i = 0; i < chestItems.Count; i++)
            {
                if (chestItems[i] == null) {
                    chestSlots[i].RemoveItem();
                } else
                {
                    chestSlots[i].ChangeItem(inventory.GetChestItems()[i], inventory.GetChestCounts()[i]);
                }
            }
        }
    }

    public void Select(Item item) {
        inventory.selected = item;

        titleTMP.text = item.itemName;
        titleTMP.enabled = true;
        descriptionTMP.text = item.description;
        descriptionTMP.enabled = true;

        Trader.instance.UpdateTraderUI();
    }

    public void Deselect() {
        inventory.selected = null;

        titleTMP.text = "";
        titleTMP.enabled = false;
        descriptionTMP.text = "";
        descriptionTMP.enabled = false;
    }
}
