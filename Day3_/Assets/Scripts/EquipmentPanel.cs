using System;
using UnityEngine;

public class EquipmentPanel : MonoBehaviour
{
    [SerializeField] Transform equipmentParent;
    [SerializeField] EquipmentSlot[] slots;

    public event Action<Item> OnClicked;

    private void Awake()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            slots[i].OnClick += OnClicked;
        }
    }
    private void OnValidate()
    {
        slots = equipmentParent.GetComponentsInChildren<EquipmentSlot>();
    }

    public bool AddItem(Item item, out Item PreItem)
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].itemType == item.Type)
            {
                PreItem = slots[i].Item;
                slots[i].Item = item;
                return true;
            }
        }
        PreItem = null;
        return false;
    }

    public bool RemoveItem(Item item)
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].Item == item)
            {
                slots[i].Item = null;
                return true;
            }
        }
        return false;
    }
}
