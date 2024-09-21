using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Chest", menuName = "Inventory/Chest")]
public class Chest : ScriptableObject
{
    public string rarity;
    public List<Item> items;
    public List<int> counts;
}
