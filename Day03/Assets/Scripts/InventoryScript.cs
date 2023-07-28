using System;
using UnityEngine;
using UnityEngine.Serialization;

public class InventoryScript : MonoBehaviour
{
    [FormerlySerializedAs("items")]
    public ItemAsset database;
    public int InventorySize;
    public GameObject SlotPrefab;
    private InventorySlot[] slots;


    public event Action<InventorySlot> OnBeginDragEvent;
    public event Action<InventorySlot> OnDragEvent;
    public event Action<InventorySlot> OnEndDragEvent;
    public event Action<InventorySlot> OnDropEvent;

    private void Awake()
    {
        for (int i = 0; i < InventorySize; i++)
        {
            Instantiate(SlotPrefab, transform);
        }
        slots = GetComponentsInChildren<InventorySlot>();
        RefreshUI();
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
    public void RefreshUI()
    {
        int i = 0;
        for (; i < database.data.Count && i < slots.Length; i++)
        {
            slots[i].Item = database.data[i];
        }

        for (; i < slots.Length; i++)
        {
            slots[i].Item = null;
        }
    }
    public bool AddItem(ItemData item)
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].Item == null)
            {
                slots[i].Item = item;
                return true;
            }
        }
        return false;
    }

    public bool RemoveItem(ItemData item)
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

    public bool IsFull()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].Item == null)
            {
                return false;
            }
        }
        return true;
    }

    public void CreateItem()
    {
        int index = UnityEngine.Random.Range(0, database.data.Count);

        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].Item == null)
            {
                slots[i].Item = database.data[index];
                break;
            }
        }
    }

    public void DeleteItem()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].Item != null)
            {
                slots[i].Item = null;
                break;
            }
        }
    }
}
