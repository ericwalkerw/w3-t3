using System;
using UnityEngine;

public class EquipmentScrip : MonoBehaviour
{
    private EquipmentSlot[] slots;

    public event Action<InventorySlot> OnBeginDragEvent;
    public event Action<InventorySlot> OnDragEvent;
    public event Action<InventorySlot> OnEndDragEvent;
    public event Action<InventorySlot> OnDropEvent;

    private void Awake()
    {
        slots = GetComponentsInChildren<EquipmentSlot>();
    }

    private void Start()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            slots[i].OnBeginDragEvent += OnBeginDragEvent;
            slots[i].OnDragEvent += OnDragEvent;
            slots[i].OnEndDragEvent += OnEndDragEvent;
            slots[i].OnDropEvent += OnDropEvent;
        }
    }

    public bool AddItem(EquipableItem item, out EquipableItem PreItem)
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].type == item.Type)
            {
                PreItem = (EquipableItem)slots[i].Item;
                slots[i].Item = item;
                return true;
            }
        }
        PreItem = null;
        return false;
    }

    public bool RemoveItem(EquipableItem item)
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
