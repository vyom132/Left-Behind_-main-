using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventorySlot : MonoBehaviour
{
    public TMP_Text iconTMP; // Later change it to image
    public TMP_Text countTMP;
    Item item;
    public bool isEmpty = false;

    public void ChangeItem(Item newItem, int newCount) {
        if (item == null) {
        isEmpty = true;
        item = newItem;
        iconTMP.text = item.iconTemp;
        }

        countTMP.text = newCount.ToString();
    }
}
