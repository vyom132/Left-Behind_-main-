using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    public string itemName;
    public string description;
    public string itemInfo = "info";
    public Sprite icon;

    public virtual void Use() {
        Debug.Log("Using " + itemName);
    }
}
