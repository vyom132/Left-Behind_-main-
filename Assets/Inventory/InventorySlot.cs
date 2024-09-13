using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventorySlot : MonoBehaviour
{
    public Image icon;
    public TMP_Text countTMP;
    public TMP_Text titleTMP;
    public TMP_Text descriptionTMP;
    public bool isEmpty = true;
    Item item;

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
        if (isEmpty) {
            item = null;
            icon.enabled = false;
            countTMP.text = "";
            isEmpty = true;
        } else
        {
            Debug.Log("Slot is already empty");
        }
    }

    public void UseItem() {
        if (isEmpty) {
            Debug.Log("Slot is empty");
        } else
        {
            titleTMP.text = item.itemName;
            titleTMP.enabled = !titleTMP.enabled;
            descriptionTMP.text = item.description;
            descriptionTMP.enabled = !descriptionTMP.enabled;
            // item.Use();
        }
    }
}
