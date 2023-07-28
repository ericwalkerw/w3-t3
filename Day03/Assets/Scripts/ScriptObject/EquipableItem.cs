using UnityEngine;

[CreateAssetMenu(menuName = "Inventory/Equip Data")]
public class EquipableItem : ItemData
{
    public EquipType Type;
}

public enum EquipType
{
    Weapon1, Weapon2, Armor, Helmet
}
