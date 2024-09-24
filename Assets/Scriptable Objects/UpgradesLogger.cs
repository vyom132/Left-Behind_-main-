using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Upgrades Logger", menuName = "Inventory/Upgrades Logger")]
public class UpgradesLogger : ScriptableObject
{
    [SerializeField]
    private List<UpgradableItem> upgradableItems;
    [SerializeField]
    private List<string> itemNames;

    public UpgradableItem GetUpgradableItem(string itemName) {
        return upgradableItems[itemNames.IndexOf(itemName)];
    }
}
