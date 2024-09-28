using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UpgradingUI : MonoBehaviour
{
    [SerializeField]
    private UpgradableItem upgradableItem;
    [SerializeField]
    private InventoryStorage inventoryStorage;
    [SerializeField]
    private string enabledColor = "#6BFF00";
    [SerializeField]
    private string disabledColor = "#FF9494";

    [SerializeField]
    private Image icon;
    [SerializeField]
    private List<TMP_Text> requirements;
    [SerializeField]
    private Button upgradeButton;
    [SerializeField]
    private GameObject panelStuff;
    [SerializeField]
    private GameObject finalIcon;
    private int upgradeCheck;
    private Color newColor;
    private UpgradeRequirements reqs;

    public void UpdateUpgradingUI() {
        if (upgradableItem.InFinalLevel()) {
            panelStuff.SetActive(false);
            finalIcon.SetActive(true);
            return;
        }

        reqs = upgradableItem.GetItemRequirements();
        icon.sprite = upgradableItem.GetItemRequirements().initialIcon;

        upgradeCheck = 0;
        for (int i = 0; i < requirements.Count; i++) {
            requirements[i].text = reqs.items[i].itemName + "\n" + inventoryStorage.GetCount(reqs.items[i]) + " / " + reqs.counts[i];

            if (inventoryStorage.GetCount(reqs.items[i]) >= reqs.counts[i]) {
                ColorUtility.TryParseHtmlString(enabledColor, out newColor);
                upgradeCheck += 1;
            } else
            {
                ColorUtility.TryParseHtmlString(disabledColor, out newColor);
            }
            requirements[i].color = newColor;
        }

        upgradeButton.interactable = (upgradeCheck == 2);
    }

    public void Upgrade() {
        for (int i = 0; i < upgradableItem.GetItemRequirements().counts.Count; i++) {
            InventoryManager.instance.Decrease(upgradableItem.GetItemRequirements().items[i], upgradableItem.GetItemRequirements().counts[i]);
            Debug.Log(upgradableItem.GetItemRequirements().items[i] + " : " + upgradableItem.GetItemRequirements().counts[i]);
        }
        upgradableItem.CompleteUpgrade();
        UpdateUpgradingUI();
    }
}
