using UnityEngine;

[CreateAssetMenu(fileName = "New Currency Material", menuName = "Inventory/Item/Currency Material")]
public class CurrencyMaterial : Item
{
    public int value;

    public override void Use() {
        InventoryManager.instance.currency += value;
        Debug.Log("Increased currency by " + value);
    }
}
