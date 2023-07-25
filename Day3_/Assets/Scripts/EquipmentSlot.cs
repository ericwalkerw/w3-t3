using UnityEngine;
using UnityEngine.EventSystems;

public class EquipmentSlot : ItemSlot
{
    public ItemType itemType;

    protected override void OnValidate()
    {
        base.OnValidate();
        gameObject.name = itemType.ToString();
    }

    public override void OnDrop(PointerEventData eventData)
    {
        GameObject dropped = eventData.pointerDrag;
        Draggable draggableItem = dropped.GetComponent<Draggable>();
        if (draggableItem.Item == null)
        {
            Debug.Log("Null");
            return;
        }
        if (draggableItem.Item.Type != itemType)
        {
            Debug.Log("NotType");
            return;
        }
        base.OnDrop(eventData);
    }
}
