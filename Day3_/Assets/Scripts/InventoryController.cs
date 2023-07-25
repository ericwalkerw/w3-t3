using UnityEngine;

public class InventoryController : MonoBehaviour
{
    [SerializeField] Inventory inventory;
    [SerializeField] EquipmentPanel equipmentPanel;

    private void Awake()
    {
        inventory.OnClicked += EquipFromInv;
        equipmentPanel.OnClicked += UnEquipFromInv;
    }

    private void EquipFromInv(Item item)
    {
        if (item is Item)
        {
            Equip(item);
        }
    }
    private void UnEquipFromInv(Item item)
    {
        if (item is Item)
        {
            Unequip(item);
        }
    }

    public void Equip(Item item)
    {
        if (inventory.RemoveItem(item))
        {
            Item PreItem;
            if (equipmentPanel.AddItem(item, out PreItem))
            {
                if (PreItem != null)
                {
                    inventory.AddItem(PreItem);
                }
            }
            else
            {
                inventory.AddItem(item);
            }
        }
    }

    public void Unequip(Item item)
    {
        if (!inventory.IsFull() && equipmentPanel.RemoveItem(item))
        {
            inventory.AddItem(item);
        }
    }
}
