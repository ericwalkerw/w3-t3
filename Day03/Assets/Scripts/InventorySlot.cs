using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IDropHandler
{
    public Image icon;

    public event Action<InventorySlot> OnBeginDragEvent;
    public event Action<InventorySlot> OnDragEvent;
    public event Action<InventorySlot> OnEndDragEvent;
    public event Action<InventorySlot> OnDropEvent;

    private ItemData _item;
    public ItemData Item
    {
        get => _item;
        set
        {
            _item = value;

            if (_item == null)
            {
                icon.color = disableIcon;
            }
            else
            {
                icon.sprite = _item.Icon;
                icon.color = Color.white;
            }
        }
    }

    private Color disableIcon = new Color(0, 0, 0, 0);

    public virtual bool CanReceiveItem(ItemData item)
    {
        return true;
    }
    public void OnBeginDrag(PointerEventData eventData) => OnBeginDragEvent?.Invoke(this);
    public void OnDrag(PointerEventData eventData) => OnDragEvent?.Invoke(this);
    public void OnEndDrag(PointerEventData eventData) => OnEndDragEvent?.Invoke(this);

    public void OnDrop(PointerEventData eventData) => OnDropEvent?.Invoke(this);
}
