using UnityEngine;
using UnityEngine.UI;

public class InventoryController : MonoBehaviour
{
    [SerializeField] EquipmentScrip EquipScreen;
    [SerializeField] InventoryScript InventoryScreen;

    [SerializeField] Image draggableItem;
    private InventorySlot draggedSlot;

    private void Awake()
    {
        InventoryScreen.OnBeginDragEvent += BeginDrag;
        EquipScreen.OnBeginDragEvent += BeginDrag;

        InventoryScreen.OnDragEvent += Drag;
        EquipScreen.OnDragEvent += Drag;

        InventoryScreen.OnEndDragEvent += EndDrag;
        EquipScreen.OnEndDragEvent += EndDrag;

        InventoryScreen.OnDropEvent += Drop;
        EquipScreen.OnDropEvent += Drop;
    }

    #region SetUp Event
    private void BeginDrag(InventorySlot slot)
    {
        if (slot.Item != null)
        {
            slot.icon.enabled = false;
            draggedSlot = slot;
            draggableItem.sprite = slot.Item.Icon;
            draggableItem.transform.position = Input.mousePosition;
            draggableItem.gameObject.SetActive(true);
        }
    }
    private void Drag(InventorySlot slot)
    {
        draggableItem.transform.position = Input.mousePosition;
    }

    private void EndDrag(InventorySlot slot)
    {
        slot.icon.enabled = true;

        draggedSlot = null;
        draggableItem.gameObject.SetActive(false);
    }
    private void Drop(InventorySlot DropItemslot)
    {
        if (DropItemslot.CanReceiveItem(draggedSlot.Item) && draggedSlot.CanReceiveItem(DropItemslot.Item))
        {
            EquipableItem dragItem = draggedSlot.Item as EquipableItem;
            EquipableItem dropItem = DropItemslot.Item as EquipableItem;
            SwapItem(DropItemslot);
        }
    }

    private void SwapItem(InventorySlot slot)
    {
        ItemData draggedItem = draggedSlot.Item;
        draggedSlot.Item = slot.Item;
        slot.Item = draggedItem;
    }



    #endregion

    #region LogicEquip
    public void Equip(EquipableItem item)
    {
        if (InventoryScreen.RemoveItem(item))
        {
            EquipableItem PreItem;
            if (EquipScreen.AddItem(item, out PreItem))
            {
                if (PreItem != null)
                {
                    InventoryScreen.AddItem(PreItem);
                }
            }
            else
            {
                InventoryScreen.AddItem(item);
            }
        }
    }

    public void UnEquip(EquipableItem item)
    {
        if (!InventoryScreen.IsFull() && EquipScreen.RemoveItem(item))
        {
            InventoryScreen.AddItem(item);
        }
    }

    #endregion
}
