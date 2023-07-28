public class EquipmentSlot : InventorySlot
{
    public EquipType type;

    private void Awake()
    {
        transform.name = type.ToString();
    }

    public override bool CanReceiveItem(ItemData item)
    {
        if (item == null)
        {
            return true;
        }

        EquipableItem equipItem = item as EquipableItem;
        return equipItem != null && equipItem.Type == type;
    }
}
