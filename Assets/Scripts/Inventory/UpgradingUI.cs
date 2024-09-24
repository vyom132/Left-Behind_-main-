using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UpgradingUI : MonoBehaviour
{
    [SerializeField]
    private UpgradesLogger upgradesLogger;

    [SerializeField]
    private Image icon;
    [SerializeField]
    private GameObject requirementsContainer;
    [SerializeField]
    private Button upgradeButton;
    public string itemToUpgrade;

    public void UpdateUpgradingUI() {
        UpgradeRequirements reqs = upgradesLogger.GetUpgradableItem(itemToUpgrade).GetItemRequirements();
        for (int i = 0; i < reqs.items.Count; i++) {
            Debug.Log(reqs.items[i] + " : " + reqs.counts[i]);
        }
    }
}
