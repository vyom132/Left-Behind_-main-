using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    public static InventoryUI instance; void Awake() { instance = this; }

    [SerializeField]
    private TMP_Text titleTMP;
    [SerializeField]
    private TMP_Text descriptionTMP;

    [SerializeField]
    private GameObject slotsPanel;
    [SerializeField]
    private GameObject chestPanel;
    [SerializeField]
    private Button collectButton;

    private InventoryManager inventory;
    private InventorySlot[] inventorySlots;
    private InventorySlot[] chestSlots;
    private List<Item> chestItems;
    private List<int> chestCounts;

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
            ToggleInventory(true, inventory.nearChest);
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
            inventory.selected = null;

            TradingManager.instance.UpdateTraderUI();
        } else
        {
            GetComponent<Canvas>().enabled = false;
            chestPanel.SetActive(false);

            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            inventory.selected = null;
            Deselect();
        }
    }

    public void UpdateUI(bool afterCollection = false) {
        Debug.Log("Updating inventory UI");

        for (int i = 0; i < inventory.inventoryStorage.counts.Count; i++)
        {
            if (inventory.inventoryStorage.counts[i] == 0) {
                inventorySlots[i].RemoveItem();
            } else
            {
                inventorySlots[i].ChangeItem(inventory.inventoryStorage.items[i], inventory.inventoryStorage.counts[i]);
            }
        }

        if (inventory.nearChest) {
            chestItems = inventory.GetChest().items;
            chestCounts = inventory.GetChest().counts;

            for (int i = 0; i < chestItems.Count; i++)
            {
                if (chestItems[i] == null) {
                    chestSlots[i].RemoveItem();
                } else
                {
                    chestSlots[i].ChangeItem(chestItems[i], chestCounts[i]);
                }
            }
        } else if (afterCollection)
        {
            foreach (var item in chestSlots) {
                item.RemoveItem();
            }
        }

        collectButton.interactable = inventory.nearChest;
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
            descriptionTMP.text = "";
        } else
        {
            titleTMP.text = item.itemName;
            descriptionTMP.text = item.description;
        }
    }
}
