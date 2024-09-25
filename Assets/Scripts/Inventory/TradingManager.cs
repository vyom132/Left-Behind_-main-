using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TradingManager : MonoBehaviour
{
    public static TradingManager instance; void Awake() { instance = this; }

    InventorySlot[] traderSlots;
    InventoryManager inventory;
    TradeItems tradeItems;
    int importIndex;

    public Transform player;
    public TMP_Text infoTMP;
    public Button tradeButton;
    public GameObject tradePanel;

    void Start() {
        traderSlots = tradePanel.GetComponentsInChildren<InventorySlot>();
        inventory = InventoryManager.instance;
    }

    void OnTriggerEnter(Collider collider) {
        if (collider.CompareTag("Player")) {
            inventory.nearStore = true;
        }
    }

    void OnTriggerExit(Collider collider) {
        if (collider.CompareTag("Player")) {
            inventory.nearStore = false;
        }
    }

    public void UpdateTraderUI(bool active=true) {
        Debug.Log("Updating trader UI");

        if (!inventory.nearStore) {
            tradePanel.SetActive(false);
            return;
        } else
        {
            tradePanel.SetActive(true);
        }

        if (inventory.selected == null || !inventory.selected.isTradable) {
            infoTMP.text = "(Select a tradable item to begin trading)";
            tradeButton.interactable = false;

            for (int i = 0; i < traderSlots.Length; i++)
            {
                traderSlots[i].RemoveItem();
            }
        } else
        {
            Item exportItem = inventory.selected;
            tradeItems = exportItem.importItems;

            for (int i = 0; i < traderSlots.Length; i++)
            {
                traderSlots[i].ChangeItem(tradeItems.items[i], tradeItems.counts[i]); // Check TradeItems.cs for more information
            }

            InitiateTrade(null);
        }
    }

    public void InitiateTrade(Item item) {
        if (item == null) {
            infoTMP.text = "(Select an item to trade for)";
            tradeButton.interactable = false;
        } else
        {
            importIndex = tradeItems.items.IndexOf(item);

            infoTMP.text = "Trade 1 " + inventory.selected.itemName + " for " + tradeItems.counts[importIndex] + " " + tradeItems.items[importIndex].itemName + "?";
            tradeButton.interactable = true;
        }
    }

    public void Trade() {
        inventory.Increase(tradeItems.items[importIndex], tradeItems.counts[importIndex]);
        inventory.Decrease(inventory.selected, 1);
        InventoryUI.instance.UpdateUI();
        UpdateTraderUI();
    }
}
