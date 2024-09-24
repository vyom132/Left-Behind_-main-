using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Upgrade Requirement", menuName = "Inventory/Upgrade Requirement")]
public class UpgradeRequirements : ScriptableObject
{
    public string toUpgrade;
    public int levelTransition;
    public Sprite finalIcon;
    public List<Item> items;
    public List<int> counts;
}
