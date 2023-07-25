using UnityEngine;
public enum ItemType { None, Helmet, Chest, Gloves, Boots, Weapon1, Weapon2, Accessory1, Accessory2, Flask }
[CreateAssetMenu]
public class Item : ScriptableObject
{
    public string ItemName;
    public Sprite Icon;
    public ItemType Type;
}
