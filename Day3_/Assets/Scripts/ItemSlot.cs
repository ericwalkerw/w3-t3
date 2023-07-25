using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour, IPointerClickHandler, IDropHandler
{
    [SerializeField] Image image;

    public event Action<Item> OnClick;

    private Color normalColor = Color.white;
    private Color disableColor = new Color(1, 1, 1, 0);
    [SerializeField] protected Draggable draggable;
    public Draggable Draggable => draggable;

    private Item _item;
    public Item Item
    {
        get { return _item; }
        set
        {
            _item = value;
            if (_item == null)
                image.color = disableColor;
            else
            {
                image.sprite = _item.Icon;
                image.color = normalColor;
            }
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData != null && eventData.button == PointerEventData.InputButton.Right)
        {
            if (Item != null && OnClick != null)
            {
                OnClick(Item);
            }
        }
    }

    protected virtual void OnValidate()
    {
        if (image == null)
            image = GetComponentInChildren<Image>();
        if (draggable == null)
            draggable = GetComponentInChildren<Draggable>();
    }

    #region Drag
    public virtual void OnDrop(PointerEventData eventData)
    {
        GameObject dropped = eventData.pointerDrag;
        Draggable draggableItem = dropped.GetComponent<Draggable>();

        if (transform.childCount == 0)
        {
            draggableItem.parentAfterDrag = transform;
        }
        else
        {
            draggableItem.parentAfterDrag = transform;
            transform.GetChild(0).SetParent(draggableItem.parentBeforeDrag);
        }
    }
    #endregion
}
