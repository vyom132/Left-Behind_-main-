using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Upgradable Item", menuName = "Inventory/Upgradable Item")]
public class UpgradableItem : ScriptableObject
{
    public int currentLevel;
    // public Sprite initialIcon;

    [SerializeField]
    private List<UpgradeRequirements> upgrades;

    public void CompleteUpgrade() {
        currentLevel += 1;
    }

    public bool InFinalLevel() {
        return (currentLevel == upgrades[upgrades.Count - 1].levelTransition + 1);
    }

    public UpgradeRequirements GetItemRequirements() {
        return upgrades[currentLevel];
    }
}
