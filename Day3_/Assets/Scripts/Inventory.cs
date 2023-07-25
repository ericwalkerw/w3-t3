using System;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] List<Item> items;
    [SerializeField] Transform ItemsParent;
    [SerializeField] ItemSlot[] slots;

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
        if (ItemsParent != null)
            slots = GetComponentsInChildren<ItemSlot>();
        RefresherUI();
    }

    private void RefresherUI()
    {
        int i = 0;

        for (; i < items.Count && i < slots.Length; i++)
        {
            slots[i].Item = items[i];
            slots[i].Draggable.Item = items[i];

        }

        for (; i < slots.Length; i++)
        {
            slots[i].Item = null;
        }
    }

    public bool AddItem(Item item)
    {
        if (IsFull()) return false;

        items.Add(item);
        RefresherUI();
        return true;
    }

    public bool RemoveItem(Item item)
    {
        if (items.Remove(item))
        {
            RefresherUI();
            return true;
        }
        return false;
    }

    public bool IsFull() => items.Count >= slots.Length;
}
