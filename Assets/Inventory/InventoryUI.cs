using UnityEngine;
using TMPro;

public class InventoryUI : MonoBehaviour
{
    public static InventoryUI instance; void Awake() { instance = this; }

    public Transform slotsPanel;
    InventoryManager inventory;
    InventorySlot[] slots;

    public TMP_Text titleTMP;
    public TMP_Text descriptionTMP;
    public TMP_Text infoTMP;
    public GameObject button;

    void Start()
    {
        GetComponent<Canvas>().enabled = false;
        inventory = InventoryManager.instance;
        inventory.onInventoryChangeCallback += UpdateUI;

        slots = slotsPanel.GetComponentsInChildren<InventorySlot>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) {
            GetComponent<Canvas>().enabled = true;
        }

        if (Input.GetKeyDown(KeyCode.Escape)) {
            GetComponent<Canvas>().enabled = false;
            inventory.inStore = false;

            infoTMP.enabled = false;
            button.SetActive(false);

            inventory.selected = null;
            Deselect();
        }
    }

    void UpdateUI() {
        Debug.Log("Updating UI");
        for (int i = 0; i < inventory.items.Count; i++)
        {
            if (inventory.counts[i] == 0) {
                slots[i].RemoveItem();
            } else
            {
                slots[i].ChangeItem(inventory.items[i], inventory.counts[i]);
            }
        }
    }

    public void Select(Item item) {
        inventory.selected = item;

        titleTMP.text = item.itemName;
        titleTMP.enabled = true;
        descriptionTMP.text = item.description;
        descriptionTMP.enabled = true;

        if (inventory.inStore) {
            button.SetActive(true);
            infoTMP.enabled = true;
            infoTMP.text = item.itemInfo;
        }
    }

    public void Deselect() {
        inventory.selected = null;

        titleTMP.text = "";
        titleTMP.enabled = false;
        descriptionTMP.text = "";
        descriptionTMP.enabled = false;

        if (inventory.inStore) {
            button.SetActive(false);
            infoTMP.enabled = false;
            infoTMP.text = "";
        }
    }

    public void Sell() {
        inventory.selected.Use();
    }
}
