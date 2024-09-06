using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public Transform itemsParent;
    InventoryManager inventory;
    InventorySlot[] slots;

    void Start()
    {
        GetComponent<Canvas>().enabled = false;
        inventory = InventoryManager.instance;
        inventory.onInventoryChangeCallback += UpdateUI;

        slots = itemsParent.GetComponentsInChildren<InventorySlot>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            GetComponent<Canvas>().enabled = !GetComponent<Canvas>().enabled;
        }
    }

    void UpdateUI() {
        Debug.Log("Updating UI");
        for(int i = 0; i < inventory.counts.Count; i++)
        {
            slots[i].ChangeItem(inventory.items[i], inventory.counts[i]);
        }
    }
}
