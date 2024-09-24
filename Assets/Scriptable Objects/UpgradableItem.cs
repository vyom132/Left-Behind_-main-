using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Upgradable Item", menuName = "Inventory/Upgradable Item")]
public class UpgradableItem : ScriptableObject
{
    [SerializeField]
    private Sprite initialIcon;
    [SerializeField]
    private List<UpgradeRequirements> upgrades;
    [SerializeField]
    private List<bool> upgradesDone;
    [SerializeField]
    private int currentLevel;
    [SerializeField]
    private string itemToUpgrade;

    public void CompleteUpgrade() {
        upgradesDone[currentLevel] = true;
        currentLevel += 1;
    }

    public UpgradeRequirements GetItemRequirements() {
        return upgrades[currentLevel];
    }
}
